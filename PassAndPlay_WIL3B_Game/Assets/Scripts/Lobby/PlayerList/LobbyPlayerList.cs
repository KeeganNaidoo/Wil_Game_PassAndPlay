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
		[SerializeField] private PlayerListItemUI playerListItemPrefab;
		private List<PlayerListItemUI> playerListUI = new();
		[SerializeField] private AddPlayerUI addPlayerUI;

		private void Awake()
		{
		}

		private void ShowAddPlayerUI()
		{
			
		}
	}
}
