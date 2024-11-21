using UnityEngine;
using UnityEngine.UI;


namespace WilGame
{
	
	public class AvatarSelectionItem : MonoBehaviour
	{
		[SerializeField] private Image avatarImage;
		[SerializeField] private Toggle selectButton;
		[SerializeField] private Image selectIndicatorImage;
		private int _avatarIndex;
		
		private void OnEnable()
		{
			DeselectAvatar();
			selectButton.onValueChanged.AddListener(SelectAvatar);
		}
		private void OnDisable()
		{
			selectButton.onValueChanged.RemoveListener(SelectAvatar);
		}

		private void SelectAvatar(bool isSelected)
		{
			if (isSelected)
			{
				EventManager.OnAvatarSelected.Invoke(_avatarIndex);
				selectIndicatorImage.gameObject.SetActive(true);
			}
			else
			{
				EventManager.OnAvatarSelected.Invoke(-1);
				DeselectAvatar();
			}
		}
		
		public void AssignAvatar(int avatarIndex, Sprite avatarSprite)
		{
			_avatarIndex = avatarIndex;
			avatarImage.sprite = avatarSprite;
		}
		
		public void DeselectAvatar()
		{
			selectIndicatorImage.gameObject.SetActive(false);
			selectButton.isOn = false;
		}

		public void SetUnavailable()
		{
			selectButton.interactable = false;
		}
		
		public void SetAvailable()
		{
			selectButton.interactable = true;
		}

		public void ResetItem()
		{
			DeselectAvatar();
			selectButton.interactable = true;
		}
	}
}
