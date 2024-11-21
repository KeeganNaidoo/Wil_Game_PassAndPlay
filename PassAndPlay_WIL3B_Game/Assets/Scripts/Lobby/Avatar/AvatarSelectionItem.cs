using UnityEngine;
using UnityEngine.UI;


namespace WilGame
{
	
	public class AvatarSelectionItem : MonoBehaviour
	{
		[SerializeField] private Image avatarImage;
		[SerializeField] private Button selectButton;
		[SerializeField] private Image selectIndicatorImage;
		
		private void OnEnable()
		{
			selectButton.onClick.AddListener(SelectAvatar);
		}

		private void SelectAvatar()
		{
			
		}

		private void OnDisable()
		{
			selectButton.onClick.RemoveListener(SelectAvatar);
		}
		
		
	}
}
