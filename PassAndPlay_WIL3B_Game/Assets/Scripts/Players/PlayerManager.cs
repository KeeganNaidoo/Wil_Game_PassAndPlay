using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
			EventManager.OnRemovePlayer.Subscribe(RemovePlayer);
		}
		private void OnDisable()
		{
			EventManager.OnRemovePlayer.Unsubscribe(RemovePlayer);
		}

		public void CreateStoreAndBroadcastNewPlayer(string name, Sprite avatar)
		{
			PlayerData player = new PlayerData(name, avatar);
			player.Id = Players.Count;
			player.TurnOrder = player.Id + 1; // start at 1
			Players.Add(player);
			EventManager.OnPlayerCreated.Invoke(player);
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
			PlayerData player = GetPlayer(playerId);
			EventManager.OnSendTargetRemovePlayerAvatarBeforeRemoving.Invoke(player.Avatar);
			Players.RemoveAt(playerId);
			if (Players.Count > 0)
			{
				for (int i = playerId; i < Players.Count; i++) // shift the rest of the players ahead of the removed player
				{
					var playerData = Players[i];
					playerData.Id--;
					playerData.TurnOrder--;
					Players[i] = playerData;
				}
			}
		}

		public PlayerData GetPlayer(int playerId)
		{
			return Players.Find(x => x.Id == playerId);
		}
	}
}
