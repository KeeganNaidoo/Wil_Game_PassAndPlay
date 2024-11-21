using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WilGame.Players;
using System.Threading.Tasks;

namespace WilGame
{
	
	public class LobbyPlayerList : MonoBehaviour
	{
		[SerializeField] private int maxPlayers = 8;
		[SerializeField] private PlayerListItemUI playerListItemPrefab;
		private List<PlayerListItemUI> playerListUI = new();
		[SerializeField] private AddPlayerUI addPlayerUI;

		private void OnEnable()
		{
			EventManager.OnCreatePlayer.Subscribe(ListNewPlayer);
		}

		private async void ListNewPlayer(PlayerData player)
		{
			await Task.Yield(); // wait so that other scripts have finished creating the player before assigning the values for the player.
			RemoveAddPlayerUI();
			var playerListItem = Instantiate(playerListItemPrefab, transform);
			playerListItem.Init(player);
			playerListUI.Add(playerListItem);
			if (playerListUI.Count < maxPlayers)
			{
				ShowAddPlayerUI();
			}
		}

		private void RemoveAddPlayerUI()
		{
			addPlayerUI.gameObject.SetActive(false);
		}

		private void ShowAddPlayerUI()
		{
			addPlayerUI.gameObject.SetActive(true);
		}
	}
}
