using System.Collections.Generic;

namespace WilGame.Scenarios
{
    public interface Scenarios
    {
        public List<Scenario> ScenariosList { get; }
        public Scenario GetScenarioById(int id);
        public int Count => ScenariosList.Count;
    }
}