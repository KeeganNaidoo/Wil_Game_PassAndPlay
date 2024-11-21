using UnityEngine;
using System.Collections.Generic;

namespace WilGame.Scenarios
{
    public class ScenarioManager : MonoBehaviour
    {
        private List<string> scenarios = new List<string> { "Scenario 1", "Scenario 2", "Scenario 3" };
        private List<string> prompts = new List<string> { "Comment", "Hashtag", "Spin the Headline" };

        public (string scenario, string prompt) GetRandomScenario()
        {
            string randomScenario = scenarios[Random.Range(0, scenarios.Count)];
            string randomPrompt = prompts[Random.Range(0, prompts.Count)];
            return (randomScenario, randomPrompt);
        }
    }
}