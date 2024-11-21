using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WilGame.Players;


namespace WilGame
{
	
	public class LobbyPlayerList : MonoBehaviour
	{
		[SerializeField] private int maxPlayers = 8;
		private List<PlayerData> _players = new();

		private void Awake()
		{
		}

		private void ShowAddPlayerUI()
		{
			
		}
	}
}
