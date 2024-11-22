using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WilGame.Players;
using System.Threading.Tasks;
using UnityEngine.Serialization;

namespace WilGame
{
	
	public class LobbyPlayerList : MonoBehaviour
	{
		[SerializeField] private int maxPlayers = 8;
		[SerializeField] private PlayerListItemUI playerListItemPrefab;
		private List<PlayerListItemUI> _playerListUI = new();
		[FormerlySerializedAs("addPlayerUI")] [SerializeField] private AddPlayerUI addPlayerUIPrefab;
		private AddPlayerUI _addPlayerUI;

		private void Start()
		{
			EventManager.OnPlayerCreated.Subscribe(ListNewPlayer);
			EventManager.OnRemovePlayer.Subscribe(UpdatePlayerListItemsAndRemovePlayer);
			CreateAddPlayerUI();
		}

		private void UpdatePlayerListItemsAndRemovePlayer(int playerIndex)
		{
			for (int i = playerIndex + 1; i < _playerListUI.Count; i++)
			{
				_playerListUI[i].DecrementTurnOrderNumberAndId();
			}
			Debug.Log("Remove player index: " + playerIndex);
			Destroy(_playerListUI[playerIndex].gameObject);
			_playerListUI.RemoveAt(playerIndex);
		}

		private void OnDestroy()
		{
			EventManager.OnPlayerCreated.Unsubscribe(ListNewPlayer);
		}

		private void ListNewPlayer(PlayerData player)
		{
			RemoveAddPlayerUI();
			var playerListItem = Instantiate(playerListItemPrefab, transform);
			playerListItem.Init(player);
			_playerListUI.Add(playerListItem);
			if (_playerListUI.Count < maxPlayers)
			{
				CreateAddPlayerUI();
			}
		}

		private void RemoveAddPlayerUI()
		{
			Destroy(_addPlayerUI.gameObject);
		}

		private void CreateAddPlayerUI()
		{
			_addPlayerUI = Instantiate(addPlayerUIPrefab, transform);
		}
	}
}
