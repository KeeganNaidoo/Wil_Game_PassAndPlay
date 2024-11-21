using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WilGame.Players;


namespace WilGame
{
	
	public class PlayerListItemUI : MonoBehaviour
	{
		[SerializeField] private Image playerAvatar;
		[SerializeField] private TextMeshProUGUI playerName;
		[SerializeField] private TextMeshProUGUI playerNumberText;
		[SerializeField] private Button removePlayerButton;
		private int _playerId;
		
		private void OnEnable()
		{
			removePlayerButton.onClick.AddListener(RemovePlayer);
		}

		private void OnDisable()
		{
			removePlayerButton.onClick.RemoveListener(RemovePlayer);
		}

		public void Init(PlayerData player)
		{
			playerAvatar.sprite = player.Avatar;
			playerName.text = player.Name;
			_playerId = player.Id;
			playerNumberText.text = player.TurnOrder.ToString();
		}
		
		private void RemovePlayer()
		{
			EventManager.OnRemovePlayer.Invoke(_playerId);
		}
	}
}
