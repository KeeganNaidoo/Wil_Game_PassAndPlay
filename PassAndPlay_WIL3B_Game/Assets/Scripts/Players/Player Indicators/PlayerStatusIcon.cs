using UnityEngine;

namespace WilGame.Players.Player_Indicators
{
    [System.Serializable]
    public class PlayerStatusIcon
    {
        public Sprite Icon;
        public int Id; // corresponds to the status enum number
    }
}