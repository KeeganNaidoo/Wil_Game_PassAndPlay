using System.Collections.Generic;
using UnityEngine;

namespace WilGame.Scenarios
{
    
    public class ScenariosSO : ScriptableObject, Scenarios
    {
        [field: SerializeField] public List<Scenario> ScenariosList { get; private set; }
    }
}