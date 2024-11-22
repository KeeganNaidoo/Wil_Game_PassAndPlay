using TMPro;
using UnityEngine;


namespace WilGame
{
	
	public class AnswerInputField : MonoBehaviour
	{
		[SerializeField] protected TMP_InputField answerInputField;
		[SerializeField] protected int answerCharacterLimit = 200;
		public bool IsAnswerValid
		{
			get => answerInputField.text.Length > 2;
		}

		protected virtual void Init()
		{
			answerInputField.characterLimit = answerCharacterLimit;
		}
		
		
		
		
	}
}
