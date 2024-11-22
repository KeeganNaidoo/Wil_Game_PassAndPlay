using UnityEngine;
using System.Collections.Generic;
using UnityUtils;
using Random = System.Random;

namespace WilGame.Scenarios
{
    public class ScenarioManager : PersistentSingleton<ScenarioManager>
    {
        [SerializeField] private ScenariosSO scenarios;
        public Scenario CurrentScenario { get; private set; }
        
        private List<int> _scenarioIdsToDrawFrom = new List<int>();
        
        private void PopulateScenarioIdsToDrawFrom()
        {
            foreach (var scenario in scenarios.ScenariosList)
            {
                _scenarioIdsToDrawFrom.Add(scenario.Id);
            }
        }

        public Scenario GetRandomScenario()
        {
            if (_scenarioIdsToDrawFrom.Count == 0)
            {
                PopulateScenarioIdsToDrawFrom();
            }
            var random = new Random();
            var index = random.Next(0, _scenarioIdsToDrawFrom.Count);
            var id = _scenarioIdsToDrawFrom[index];
            _scenarioIdsToDrawFrom.RemoveAt(index);
            CurrentScenario = scenarios.GetScenarioById(id);
            return CurrentScenario;
        }
        
    }
}