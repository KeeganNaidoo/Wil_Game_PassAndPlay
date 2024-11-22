using System;
using TMPro;
using UnityEngine;
using WilGame.Players;
using WilGame.Rounds;


namespace WilGame
{
	
	public class GeneralPlayerTurnUI : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI playerName;
		[SerializeField] private TextMeshProUGUI roundText;

		private void Start()
		{
			playerName.text = $"{PlayerManager.Instance.GetCurrentPlayer().Name}'s turn";
			roundText.text = "Round " + RoundManager.Instance.CurrentRoundNumber;
		}
	}
}
