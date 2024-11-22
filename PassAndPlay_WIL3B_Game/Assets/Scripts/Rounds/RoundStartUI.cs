using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using WilGame.Rounds;
using WilGame.Scenarios;


namespace WilGame
{
    public class RoundStartUI : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI roundNumberText;
        [SerializeField] private TextMeshProUGUI roundTypeText;
        
        [SerializeField] private TextMeshProUGUI scenarioDescriptionText; // Scenario Description
        [SerializeField] private TextMeshProUGUI pointsText; // Points for the scenario
        [SerializeField] private Button continueButton;

        private RoundManager roundManager;
        private ScenarioManager scenarioManager;
        // Start is called before the first frame update
        void Start()
        {
            roundManager = RoundManager.Instance;
            scenarioManager = ScenarioManager.Instance;
            DisplayRoundDetails();
            
            continueButton.onClick.AddListener(Continue);
        }

        // Update is called once per frame
        void OnDestroy()
        {
            continueButton.onClick.RemoveListener(Continue);
        }

        private void Continue()
        {
            SceneManager.LoadScene("Answers"); // Load next scene()
        }

        private void DisplayRoundDetails()
        {
            // Fetch round details
            roundNumberText.text = $"Round {roundManager.CurrentRoundNumber}";
            roundTypeText.text = $"Round Type: {roundManager.CurrentRoundType ?? roundManager.PickRandomRoundType()}";

            // Fetch scenario details
            Scenario currentScenario = scenarioManager.GetRandomScenario(); // Get a random scenario
            
            
                //scenarioIdText.text = $"Scenario #{currentScenario.id}";
                scenarioDescriptionText.text = currentScenario.Text;
                pointsText.text = $"Points: {currentScenario.Score}";
          
        } 
        

        
    }
}
