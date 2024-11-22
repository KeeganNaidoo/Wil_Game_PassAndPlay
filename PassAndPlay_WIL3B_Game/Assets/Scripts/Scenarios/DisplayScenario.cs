using System;
using TMPro;
using UnityEngine;
using WilGame.Scenarios;


namespace WilGame
{
	
	public class DisplayScenario : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI scenarioText;

		private void Start()
		{
			scenarioText.text = ScenarioManager.Instance.CurrentScenario.Text;
		}
	}
}
