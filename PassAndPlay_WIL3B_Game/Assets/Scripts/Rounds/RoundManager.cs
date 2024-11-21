using Unity.VisualScripting;
using UnityEngine;
using UnityUtils;

namespace WilGame.Rounds
{
    public class RoundManager : PersistentSingleton<RoundManager>
    {
        [SerializeField] private int maxRounds = 10;
        public int CurrentRoundNumber { get; private set; } = 0;
        
        /// <summary>
        /// Checks if the end of the game has been reached before the next round starts
        /// </summary>
        public void EndRound()
        {
            CurrentRoundNumber++;
            if (CurrentRoundNumber > maxRounds)
            {
                CurrentRoundNumber = maxRounds;
                EventManager.OnEndMatch.Invoke();
            }
        }
    }
}