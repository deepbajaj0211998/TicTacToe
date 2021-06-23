using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
	[SerializeField]
	Transform content;
	[SerializeField]
	PlayerListing playerListing;
	[SerializeField]
	Text readyUpText;

	List<PlayerListing> listings = new List<PlayerListing>();
	RoomsCanvases roomsCanvases;
	bool ready = false;

	private void Awake()
	{
		GetCurrentRoomPlayers();
	}

	public override void OnEnable()
	{
		base.OnEnable();
		SetReadyUp(false);
	}

	public void FirstInitialize(RoomsCanvases canvases)
	{
		roomsCanvases = canvases;
	}

	void SetReadyUp(bool state)
	{
		ready = state;
		if (ready)
		{
			readyUpText.text = "R";
		}
		else
		{
			readyUpText.text = "N";
		}
	}

	public override void OnLeftRoom()
	{
		content.DestroyChildren();
	}

	void GetCurrentRoomPlayers()
	{
		if (!PhotonNetwork.IsConnected)
			return;
		if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
			return;
		foreach(KeyValuePair<int, Photon.Realtime.Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
		{
			AddPlayerListing(playerInfo.Value);
		}
	}

	void AddPlayerListing(Photon.Realtime.Player player)
	{
			PlayerListing listing = Instantiate(playerListing, content);
			if (listing != null)
			{
				listing.SetPlayerInfo(player);
				listings.Add(listing);
			}
	}

	public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
	{
		roomsCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
	}

	public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
	{
		AddPlayerListing(newPlayer);
	}

	public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
	{
		int index = listings.FindIndex(x => x.Player == otherPlayer);
		if (index != -1)
		{
			Destroy(listings[index].gameObject);
			listings.RemoveAt(index);
		}
	}

	public void OnClick_StartGame()
	{
		if (PhotonNetwork.IsMasterClient)
		{
			for (int i = 0; i < listings.Count; i++)
			{
				if(listings[i].Player != PhotonNetwork.LocalPlayer)
				{
					if (!listings[i].Ready)
						return;
				}
			}
			PhotonNetwork.CurrentRoom.IsOpen = false;
			PhotonNetwork.CurrentRoom.IsVisible = false;
			PhotonNetwork.LoadLevel(1);
		}
	}

	public void OnClick_ReadyUp()
	{
		if (!PhotonNetwork.IsMasterClient)
		{
			SetReadyUp(!ready);
			base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, ready);
		}
	}

	[PunRPC]
	void RPC_ChangeReadyState(Photon.Realtime.Player player, bool ready)
	{
		int index = listings.FindIndex(x => x.Player == player);
		if (index != -1)
		{
			listings[index].Ready = ready;
		}
	}

}
