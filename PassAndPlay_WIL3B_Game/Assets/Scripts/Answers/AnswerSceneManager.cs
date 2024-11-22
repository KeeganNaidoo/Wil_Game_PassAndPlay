using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WilGame.Players;
using TMPro;

namespace WilGame
{
    public class AnswerSceneManager : MonoBehaviour
    {
        public TMP_Text playerTurnText;
        public Image playerAvatar;
        public TMP_InputField answerInputField;
        public Button submitButton;

        private PlayerManager playerManager;

        // Start is called before the first frame update
        void Start()
        {
            playerManager = PlayerManager.Instance;
            EventManager.OnStartTurn.Subscribe(HandleStartTurn);
            EventManager.OnAllPlayersTurnFinished.Subscribe(TransitionToVoting);

            HandleStartTurn();
        }

        private void OnDestroy()
        {
            EventManager.OnStartTurn.Unsubscribe(HandleStartTurn);
            EventManager.OnAllPlayersTurnFinished.Unsubscribe(TransitionToVoting);
        }

        private void HandleStartTurn()
        {
            var currentPlayer = playerManager.GetCurrentPlayer();
            playerTurnText.text = $"{currentPlayer.Name}'s Turn";
            playerAvatar.sprite = currentPlayer.Avatar;
        }

        public void SubmitAnswer()
        {
            string answer = answerInputField.text;
            if (!string.IsNullOrEmpty(answer))
            {
                var currentPlayer = playerManager.GetCurrentPlayer();
                playerManager.RecordAnswer(currentPlayer.Id, answer);
                answerInputField.text = ""; // Clear input field

                EventManager.OnFinishTurn.Invoke();

                if (playerManager.AllPlayersAnswered())
                {
                    EventManager.OnAllPlayersTurnFinished.Invoke();
                }
                else
                {
                    playerManager.NextPlayer();
                    HandleStartTurn();
                }
            }
        }

        private void TransitionToVoting()
        {
            Debug.Log("All players have answered. Transitioning to Voting Scene...");
            SceneManager.LoadScene("VotingScene");
        }
    }
}
