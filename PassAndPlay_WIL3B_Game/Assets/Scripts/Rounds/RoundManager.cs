using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityUtils;

namespace WilGame.Rounds
{
    public class RoundManager : PersistentSingleton<RoundManager>
    {
        [SerializeField] private int maxRounds = 10;
        public int CurrentRoundNumber { get; private set; } = 0;
        public int MaxRounds => maxRounds;
        
        private List<string> _roundTypes = new List<string> { "Comment", "Hashtag", "Spin the Headline" };
        public string CurrentRoundType { get; private set; }
        
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
        public void ResetRounds()
        {
            CurrentRoundNumber = 0;
        }
        
        private string PickRandomRoundType()
        {
            CurrentRoundType = _roundTypes[Random.Range(0, _roundTypes.Count)];
            return CurrentRoundType;
        }
    }
}