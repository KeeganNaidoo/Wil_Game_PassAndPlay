using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils;


namespace WilGame.Players
{
	
	public class PlayerManager : PersistentSingleton<PlayerManager>
	{
		[HideInInspector] public List<PlayerData> Players { get; private set; } = new List<PlayerData>();

		public int PlayerCount => Players.Count;
		private int _currentPlayerId = 0; // The player who's turn it is

		private void OnEnable()
		{
			EventManager.OnCreatePlayer.Subscribe(CreateAndStoreNewPlayer);
			EventManager.OnRemovePlayer.Subscribe(RemovePlayer);
		}
		private void OnDisable()
		{
			EventManager.OnCreatePlayer.Unsubscribe(CreateAndStoreNewPlayer);
			EventManager.OnRemovePlayer.Unsubscribe(RemovePlayer);
		}

		private void CreateAndStoreNewPlayer(PlayerData player)
		{
			player.Id = Players.Count;
			player.TurnOrder = player.Id + 1; // start at 1
			Players.Add(player);
		}


		public PlayerData GetCurrentPlayer()
		{
			return GetPlayer(_currentPlayerId);
		}

		public void AddPlayer(PlayerData player)
		{
			Players.Add(player);
		}

		public void RemovePlayer(int playerId)
		{
			Players.Remove(Players.Find(x => x.Id == playerId));
		}

		public PlayerData GetPlayer(int playerId)
		{
			return Players.Find(x => x.Id == playerId);
		}
	}
}
