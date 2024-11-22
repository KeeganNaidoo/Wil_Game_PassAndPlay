using System;
using UnityEngine;


namespace WilGame
{
	
	public class HashTagInputField : AnswerInputField
	{
		private void OnEnable()
		{
			answerInputField.onValueChanged.AddListener(AddHashTag);
		}

		private void OnDisable()
		{
			answerInputField.onValueChanged.RemoveListener(AddHashTag);
		}

		private void AddHashTag(string arg0)
		{
			if (arg0[0] != '#')
			{
				answerInputField.text = $"#{arg0}";
			}
		}
	}
}
