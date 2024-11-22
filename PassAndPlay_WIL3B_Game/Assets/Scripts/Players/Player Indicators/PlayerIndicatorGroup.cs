using System;
using System.Collections.Generic;
using UnityEngine;

namespace WilGame.Players.Player_Indicators
{
    public class PlayerIndicatorGroup : MonoBehaviour
    {
        [SerializeField] private PlayerIndicator playerIndicatorPrefab;
        private List<PlayerIndicator> _playerIndicators = new List<PlayerIndicator>();
        private int currentPlayingPlayerIndex = -1;
        

        public void AddPlayerIndicator(PlayerData playerData)
        {
            var playerIndicator = Instantiate(playerIndicatorPrefab, transform);
            playerIndicator.Init(playerData);
            _playerIndicators.Add(playerIndicator);
        }

        private void Start()
        {
            EventManager.OnStartTurn.Subscribe(StartTurn);
            foreach (var player in PlayerManager.Instance.Players)
            {
                AddPlayerIndicator(player);
            }
        }

        private void OnDestroy()
        {
            EventManager.OnStartTurn.Unsubscribe(StartTurn);
        }

        private void StartTurn()
        {
            currentPlayingPlayerIndex++;
            _playerIndicators[currentPlayingPlayerIndex].SetStatus(PlayerStatus.Playing);
            if (currentPlayingPlayerIndex > 0)
            {
                _playerIndicators[currentPlayingPlayerIndex - 1].SetStatus(PlayerStatus.Finished);
            }
        }
    }
}