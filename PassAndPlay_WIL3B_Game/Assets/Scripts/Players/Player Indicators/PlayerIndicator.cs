using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WilGame.Players.Player_Indicators
{
    public class PlayerIndicator : MonoBehaviour
    {
        [SerializeField] private Image playerAvatar;
        [SerializeField] private TextMeshProUGUI playerName;
        [SerializeField] private Image statusIcon;
        [Space]
        [SerializeField, Tooltip("In order of the player's statuses enum")] private PlayerStatusIcon[] playerStatusIcons;
        private int _playerId;

        public void Init(PlayerData playerData)
        {
            playerAvatar.sprite = playerData.Avatar;
            playerName.text = playerData.Name;
            _playerId = playerData.Id;
            SetStatus(playerData.Status);
        }
        
        public void SetStatus(PlayerStatus status)
        {
            statusIcon.sprite = playerStatusIcons[(int)status].Icon;
        }
        
    }
}