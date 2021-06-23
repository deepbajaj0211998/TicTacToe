using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpaces : MonoBehaviour
{
	public Button button;
	public Text buttonText;

	private GameManager gameManager;

	public void SetSpace()
	{
		buttonText.text = gameManager.GetPlayerSide();
		button.interactable = false;
		gameManager.EndTurn();
	}

	public void SetGameManagerReference(GameManager manager)
	{
		gameManager = manager;
	}

}
