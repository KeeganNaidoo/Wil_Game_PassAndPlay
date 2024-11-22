using System;
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
        }

        private void Start()
        {
            Init();
            EventManager.OnSubmitButtonPressed.Subscribe(NextTurn);
        }

        private void OnDestroy()
        {
            EventManager.OnSubmitButtonPressed.Unsubscribe(NextTurn);
        }

        public void NextTurn()
        {
            CurrentTurn++;
            if (CurrentTurn > TotalTurns)
            {
                CurrentTurn = 1;
                EventManager.OnAllPlayersTurnFinished.Invoke();
            }
            else
            {
                EventManager.OnFinishTurn.Invoke();
            }
        }
    }
}