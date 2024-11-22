using UnityEngine;
using UnityEngine.UI;
using WilGame.Players;


namespace WilGame
{
	/// <summary>
	/// In the lobby scene. There needs to be above a min amount of players to start the match
	/// </summary>
	public class StartMatch : MonoBehaviour
	{
		[SerializeField] private int minPlayers = 2;
		[SerializeField] private Button startMatchButton;
		private int _currentNumberOfPlayers = 0;
		private void OnEnable()
		{
			startMatchButton.onClick.AddListener(StartMatchButton);
			EventManager.OnPlayerCreated.Subscribe(CountPlayerAndEvaluate);
			EventManager.OnRemovePlayer.Subscribe(DecrementPlayerCountAndEvaluate);

			ToggleEnableButton();
		}

		private void DecrementPlayerCountAndEvaluate(int playerId)
		{
			_currentNumberOfPlayers--;
			ToggleEnableButton();
		}

		private void CountPlayerAndEvaluate(PlayerData obj)
		{
			_currentNumberOfPlayers++;
			ToggleEnableButton();
		}
		
		private void ToggleEnableButton()
		{
			startMatchButton.interactable = _currentNumberOfPlayers >= minPlayers;
		}


		private void OnDisable()
		{
			startMatchButton.onClick.AddListener(StartMatchButton);
			EventManager.OnPlayerCreated.Unsubscribe(CountPlayerAndEvaluate);
			EventManager.OnRemovePlayer.Unsubscribe(DecrementPlayerCountAndEvaluate);
		}
		
		private void StartMatchButton()
		{
			GameManager.Instance.StartMatch();
		}
	}
}
