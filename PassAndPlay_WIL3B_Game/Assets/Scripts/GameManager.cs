using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;
using Eflatun.SceneReference;
using WilGame.Players;
using WilGame.Rounds;

namespace WilGame
{
    /// <summary>
    /// Handles scene management
    /// </summary>
    public class GameManager : PersistentSingleton<GameManager>
    {
        [SerializeField] private SceneReference mainMenuScene;
        [SerializeField] private SceneReference lobbyScene;
        [SerializeField, Tooltip("Must be in order. Starting from first scene after lobby")] 
        private List<SceneReference> gameLoopScenes;
        [SerializeField] private SceneReference endGameScene;

        private void OnEnable()
        {
            EventManager.OnFinishRound.Subscribe(HandleFinishRound);
            EventManager.OnEndMatch.Subscribe(HandleEndMatch);
            EventManager.OnStartMatch.Subscribe(OnStartGame);
        }

        private void OnDisable()
        {
            EventManager.OnFinishRound.Unsubscribe(HandleFinishRound);
            EventManager.OnEndMatch.Unsubscribe(HandleEndMatch);
            EventManager.OnStartMatch.Unsubscribe(OnStartGame);
            EventManager.OnFinishTurn.Subscribe(ReloadSceneForNextTurn);
        }

        private async void ReloadSceneForNextTurn()
        {
            await LoadSceneAsync(SceneManager.GetActiveScene().name);
            EventManager.OnStartTurn.Invoke();
        }

        private async void OnStartGame()
        {
            await LoadSceneAsync(lobbyScene.Name);
            EventManager.OnStartRound.Invoke(1); // Start first round
        }

        private async Task LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
            while (!asyncLoad.isDone)
            {
                await Task.Yield();
            }
        }
        
        private void HandleFinishRound()
        {
            var roundManager = RoundManager.Instance;
            roundManager.EndRound();

            if (roundManager.CurrentRoundNumber > roundManager.MaxRounds)
            {
                EventManager.OnEndMatch.Invoke();
            }
            else
            {
                EventManager.OnStartRound.Invoke(roundManager.CurrentRoundNumber);
                LoadNextGameLoopScene(roundManager.CurrentRoundNumber);
            }
        }

        private void LoadNextGameLoopScene(int roundNumber)
        {
            int nextSceneIndex = (roundNumber - 1) % gameLoopScenes.Count;
            SceneManager.LoadScene(gameLoopScenes[nextSceneIndex].Name);
        }

        private void HandleEndMatch()
        {
            SceneManager.LoadScene(endGameScene.Name);
        }

        public void StartMatch()
        {
            OnStartGame();
        }
    }
}