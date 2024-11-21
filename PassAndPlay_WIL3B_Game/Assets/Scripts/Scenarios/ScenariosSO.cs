using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WilGame.Scenarios
{
    
    [CreateAssetMenu(menuName = "Scriptable Object/Scenarios", fileName = "Scenarios")]
    public class ScenariosSO : ScriptableObject, Scenarios
    {
        [field: SerializeField] public List<Scenario> ScenariosList { get; private set; }
        public Scenario GetScenarioById(int id)
        {
            return ScenariosList.Find(x => x.Id == id);
        }

        // TODO: Create inspector button for this
        public void LoadScenariosFromCSV()
        {
            
        }
        
        
    }
}