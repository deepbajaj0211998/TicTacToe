using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{

    [SerializeField]
    Transform content;
    [SerializeField]
    RoomListing roomListing;

	List<RoomListing> listings = new List<RoomListing>();
	RoomsCanvases roomsCanvases;

	public void FirstInitialize(RoomsCanvases canvases)
	{
		roomsCanvases = canvases;
	}

	public override void OnJoinedRoom()
	{
		roomsCanvases.CurrentRoomCanvas.Show();
		content.DestroyChildren();
		listings.Clear();
	}

	public override void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		foreach(RoomInfo info in roomList)
		{
			if (info.RemovedFromList)
			{
				int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
				if(index != -1)
				{
					Destroy(listings[index].gameObject);
					listings.RemoveAt(index);
				}
			}
			else
			{
				int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
				if(index == -1)
				{
					RoomListing listing = Instantiate(roomListing, content);
					if (listing != null)
					{
						listing.SetRoomInfo(info);
						listings.Add(listing);
					}
				}
			}
		}
	}

}
