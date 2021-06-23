using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class PlayerListing : MonoBehaviour
{

    [SerializeField]
    Text text;

    public Photon.Realtime.Player Player { get; private set;}
	public bool Ready = false;

    public void SetPlayerInfo(Photon.Realtime.Player player)
	{
        Player = player;
		int result = -1;
		if (player.CustomProperties.ContainsKey("RandomNumber"))
		{
			result = (int)player.CustomProperties["RandomNumber"];
		}
		text.text = result.ToString() + ", " + player.NickName;
	}

}
