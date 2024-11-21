using Unity.VisualScripting;
using UnityEngine;
using UnityUtils;

namespace WilGame.Rounds
{
    public class RoundManager : PersistentSingleton<RoundManager>
    {
        [SerializeField] private int maxRounds = 10;
        public int CurrentRoundNumber { get; private set; } = 0;
        
    }
}