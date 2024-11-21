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
		
		public void RecordAnswer(int playerId, string answer)
		{
			var playerIndex = Players.FindIndex(p => p.Id == playerId);
			if (playerIndex != -1)
			{
				var player = Players[playerIndex];
				player.Answer = answer;
				player.Status = PlayerStatus.Finished;
				Players[playerIndex] = player;
			}
		}

		public bool AllPlayersAnswered()
		{
			return Players.TrueForAll(player => player.Status == PlayerStatus.Finished);
		}

		public void NextPlayer()
		{
			_currentPlayerId = (_currentPlayerId + 1) % PlayerCount;
		}

		public void ResetStatuses()
		{
			for (int i = 0; i < Players.Count; i++)
			{
				var player = Players[i];
				player.Status = PlayerStatus.Waiting;
				player.Answer = "";
				Players[i] = player;
			}
		}
	}
}
