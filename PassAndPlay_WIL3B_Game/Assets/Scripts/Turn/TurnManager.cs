using System;
using System.Collections.Generic;
using UnityUtils;
using WilGame.Players;

namespace WilGame.Turn
{
    public class TurnManager : PersistentSingleton<TurnManager>
    {
        public int CurrentTurn { get; private set; } = 1;
        public int TotalTurns { get; private set; } = 0;

        public void Init()
        {
            TotalTurns = PlayerManager.Instance.PlayerCount;
            EventManager.OnStartTurn.Invoke();
        }

        private void Start()
        {
            Init();
            StartFirstTurn();
            EventManager.OnSubmitButtonPressed.Subscribe(NextTurn);
        }

        private void OnDestroy()
        {
            EventManager.OnSubmitButtonPressed.Unsubscribe(NextTurn);
        }

        private void StartFirstTurn()
        {
            CurrentTurn = 1;
            List<PlayerData> players = PlayerManager.Instance.Players;
            PlayerManager.Instance.Players[0].Status = PlayerStatus.Playing;
            for (int i = 1; i < PlayerManager.Instance.PlayerCount; i++)
            {
                players[i].Status = PlayerStatus.Waiting;
            }
        }

        public void NextTurn()
        {
            CurrentTurn++;
            if (CurrentTurn > TotalTurns)
            {
                StartFirstTurn();
                EventManager.OnAllPlayersTurnFinished.Invoke();
            }
            else
            {
                PlayerManager.Instance.Players[CurrentTurn - 2].Status = PlayerStatus.Finished;
                PlayerManager.Instance.Players[CurrentTurn - 1].Status = PlayerStatus.Playing;
                EventManager.OnFinishTurn.Invoke();
            }
        }
    }
}