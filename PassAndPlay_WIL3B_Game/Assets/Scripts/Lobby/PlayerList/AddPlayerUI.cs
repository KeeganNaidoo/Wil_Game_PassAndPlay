using UnityEngine;
using UnityEngine.UI;


namespace WilGame
{
	
	public class AddPlayerUI : MonoBehaviour
	{
		[SerializeField] private Button addPlayerButton;
		
		private void OnEnable()
		{
			addPlayerButton.onClick.AddListener(AddPlayer);
		}

		private void OnDisable()
		{
			addPlayerButton.onClick.RemoveListener(AddPlayer);
		}
		
		private void AddPlayer()
		{
			EventManager.OnAddPlayer.Invoke();
		}
	}
}
