using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{

	[SerializeField]
	PlayerListingsMenu playerListingsMenu;
	[SerializeField]
	LeaveRoomMenu leaveRoomMenu;
	public LeaveRoomMenu LeaveRoomMenu { get { return leaveRoomMenu; }}
	RoomsCanvases roomsCanvases;

	public void FirstInitialize(RoomsCanvases canvases)
	{
		roomsCanvases = canvases;
		playerListingsMenu.FirstInitialize(canvases);
		leaveRoomMenu.FirstInitialize(canvases);
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

}
