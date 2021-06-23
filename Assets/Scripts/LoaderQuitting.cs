using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderQuitting : MonoBehaviour
{
	public string SceneName;

	public void Load()
	{
		SceneManager.LoadScene(SceneName);
	}

	public void Quit()
	{
		Debug.Log("Game Quitted!");
		Application.Quit();
	}
}
