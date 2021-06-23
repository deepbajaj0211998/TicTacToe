using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{

	RoomsCanvases roomsCanvases;

	public void FirstInitialize(RoomsCanvases canvases)
	{
		roomsCanvases = canvases;
	}

	public void OnClick_LeaveRoom()
	{
		PhotonNetwork.LeaveRoom(true);
		roomsCanvases.CurrentRoomCanvas.Hide();
	}

}
