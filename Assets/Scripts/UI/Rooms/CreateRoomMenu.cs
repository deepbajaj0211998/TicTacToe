using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{

	[SerializeField]
	Text roomName;

	RoomsCanvases roomsCanvases;

	public void FirstInitialize(RoomsCanvases canvases)
	{
		roomsCanvases = canvases;
	}

	public void OnClick_CreateRoom()
	{
		if (!PhotonNetwork.IsConnected)
			return;
		RoomOptions options = new RoomOptions();
		options.MaxPlayers = 4;
		PhotonNetwork.JoinOrCreateRoom(roomName.text, options, TypedLobby.Default);
	}

	public override void OnCreatedRoom()
	{
		Debug.Log("Created Room Sucessfully. ", this);
		roomsCanvases.CurrentRoomCanvas.Show();
	}

	public override void OnCreateRoomFailed(short returnCode, string message)
	{
		Debug.Log("Room Creation Failed" + message, this);
	}

}
