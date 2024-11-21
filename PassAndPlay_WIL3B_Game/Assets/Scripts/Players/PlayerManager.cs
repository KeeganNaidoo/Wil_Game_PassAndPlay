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
		private int _currentPlayerId = 0;

		private void OnEnable()
		{
			// TODO: subscribe to end turn or next turn event
		}

		private void OnDisable()
		{
			
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
