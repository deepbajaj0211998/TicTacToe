using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{

	[SerializeField]
	CreateRoomMenu createRoomMenu;

	RoomsCanvases roomsCanvases;
	[SerializeField]
	RoomListingsMenu roomListingsMenu;

    public void FirstInitialize(RoomsCanvases canvases)
	{
		roomsCanvases = canvases;
		createRoomMenu.FirstInitialize(canvases);
		roomListingsMenu.FirstInitialize(canvases);
	}

}
