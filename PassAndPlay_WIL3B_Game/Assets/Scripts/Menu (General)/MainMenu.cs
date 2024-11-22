using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace WilGame.Menu__General_
{
    public class MainMenu : MonoBehaviour
    {
        //[SerializeField] private GameObject MainScreen;
        //[SerializeField] private GameObject OptionsScreen;
        //[SerializeField] private GameObject CreditsScreen;
        //[SerializeField] private GameObject RacingGameModesScreen;
    
        [SerializeField] private Button startButton;
        //[SerializeField] private Button CreditsButton;
        //[SerializeField] private Button OptionsButton;
        //[SerializeField] private Button QuitButton;
        //[SerializeField] private Button BackButton;

        private void Start()
        {
            startButton.onClick.AddListener(StartGame);
            
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveListener(StartGame);
            
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Lobby");
        
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
