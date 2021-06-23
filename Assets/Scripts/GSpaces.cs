using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSpaces : MonoBehaviour
{
	public Button button;
	public Text buttonText;

	private GManager gManager;

	public void SetGManagerReference(GManager manager)
	{
		gManager = manager;
	}

	public void SetSpace()
	{
		buttonText.text = gManager.GetPlayerSide();
		button.interactable = false;
		gManager.EndTurn();
	}

}
