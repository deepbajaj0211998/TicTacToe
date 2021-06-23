using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerInfo
{
	public Image panel;
	public Text text;
	public Button button;
}

[System.Serializable]
public class PlayerColorInfo
{
	public Color panelColor;
	public Color textColor;
}

public class GameManager : MonoBehaviour
{
	public Text[] buttonList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;
	public PlayerInfo playerX;
	public PlayerInfo playerO;
	public PlayerColorInfo activePlayerColor;
	public PlayerColorInfo inactivePlayerColor;
	public GameObject startInfo;
	public GameObject mainMenuButton;

	private string playerSide;
	private int moveCount;

	private void Awake()
	{
		SetGameManagerReferenceOnButtons();
		gameOverPanel.SetActive(false);
		moveCount = 0;
		restartButton.SetActive(false);
		mainMenuButton.SetActive(false);
	}

	void SetGameManagerReferenceOnButtons()
	{
		for(int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<GridSpaces>().SetGameManagerReference(this);
		}
	}

	public void SetStartingSide(string startingSide)
	{
		playerSide = startingSide;
		if(playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		}
		else
		{
			SetPlayerColors(playerO, playerX);
		}
		StartGame();
	}

	void StartGame()
	{
		SetBoardInteractable(true);
		SetPlayerButtons(false);
		startInfo.SetActive(false);
	}

	public string GetPlayerSide()
	{
		return playerSide;
	}

	public void EndTurn()
	{
		moveCount++;

		if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
		{
			GameOver(playerSide);
		}

		else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
		{
			GameOver(playerSide);
		}

		else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver(playerSide);
		}

		else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver(playerSide);
		}

		else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
		{
			GameOver(playerSide);
		}

		else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver(playerSide);
		}

		else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver(playerSide);
		}

		else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver(playerSide);
		}

		else if(moveCount >= 9)
		{
			GameOver("draw");
		}
		else
		{
			ChangeSides();
		}
	}

	void SetPlayerColors(PlayerInfo newPlayer, PlayerInfo oldPlayer)
	{
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}

	void GameOver(string winningPlayer)
	{
		SetBoardInteractable(false);
		restartButton.SetActive(true);
		mainMenuButton.SetActive(true);
		if (winningPlayer == "draw")
		{
			SetGameOverText("It's a Draw!");
			SetPlayerColorsInactive();
		}
		else
		{
			SetGameOverText(winningPlayer + " Wins!");
		}
	}

	void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
		if(playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		}
		else
		{
			SetPlayerColors(playerO, playerX);
		}
	}

	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive(true);
		gameOverText.text = value;
	}

	public void RestartGame()
	{
		moveCount = 0;
		gameOverPanel.SetActive(false);
		restartButton.SetActive(false);
		SetPlayerButtons(true);
		SetPlayerColorsInactive();
		startInfo.SetActive(true);
		mainMenuButton.SetActive(false);
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].text = "";
		}
	}

	void SetBoardInteractable(bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}

	void SetPlayerButtons(bool toggle)
	{
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

	void SetPlayerColorsInactive()
	{
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerX.text.color = inactivePlayerColor.textColor;
		playerO.panel.color = inactivePlayerColor.panelColor;
		playerO.text.color = inactivePlayerColor.textColor;
	}

}
