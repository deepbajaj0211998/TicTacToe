using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
	[SerializeField]
	CreateOrJoinRoomCanvas createOrJoinRoomCanvas;

	public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas
	{
		get
		{
			return createOrJoinRoomCanvas;
		}
	}

	[SerializeField]
	CurrentRoomCanvas currentRoomCanvas;

	public CurrentRoomCanvas CurrentRoomCanvas
	{
		get
		{
			return currentRoomCanvas;
		}
	}

	private void Awake()
	{
		FirstInitialize();
	}

	private void FirstInitialize()
	{
		CreateOrJoinRoomCanvas.FirstInitialize(this);
		CurrentRoomCanvas.FirstInitialize(this);
	}

}
