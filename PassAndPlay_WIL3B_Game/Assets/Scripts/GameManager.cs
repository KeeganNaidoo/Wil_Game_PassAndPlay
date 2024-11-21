using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;
using Eflatun.SceneReference;

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
            EventManager.OnEndMatch.Subscribe(StartEndGameScene);
        }

        private void OnDisable()
        {
            EventManager.OnEndMatch.Unsubscribe(StartEndGameScene);
        }

        private void OnStartMatch()
        {
            
        }
        private void StartEndGameScene()
        {
            SceneManager.LoadScene(lobbyScene.Name);
        }
    }
}