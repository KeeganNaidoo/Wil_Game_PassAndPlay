using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WilGame.Players;
using TMPro;


namespace WilGame
{
	
	public class CreatePlayerMenu : MonoBehaviour
	{
		[SerializeField] private Button createButton;
		[SerializeField] private Button cancelButton;
		[SerializeField] private TMP_InputField playerNameInput;
		[SerializeField] private int playerNameCharacterLimit = 12;
		[SerializeField] private AvatarsSO avatars;
		private int _selectedAvatarIndex = -1; // For tracking selected avatar for when the create button is pressed
		private bool _isAvatarSelected = false;
		private bool _isNameValid = false;
		
		private void Start()
		{
			EventManager.OnAvatarSelected.Subscribe(OnAvatarSelected);
			EventManager.OnAddPlayer.Subscribe(ShowCreatePlayerMenu);
			createButton.onClick.AddListener(CreatePlayer);
			cancelButton.onClick.AddListener(() =>gameObject.SetActive(false));
			playerNameInput.characterLimit = playerNameCharacterLimit;
			playerNameInput.onValueChanged.AddListener(CheckForValidNameForCreateButton);
			gameObject.SetActive(false);

			createButton.interactable = false;
		}

		private void CheckForValidNameForCreateButton(string arg0)
		{
			_isNameValid = arg0 != string.Empty;
			SetButtonInteractableness();
		}

		private void ShowCreatePlayerMenu()
		{
			gameObject.SetActive(true);
			playerNameInput.text = "";
		}

		private void OnAvatarSelected(int index)
		{
			// Set create button as interactable if an avatar is selected
			_isAvatarSelected = index != -1;
			SetButtonInteractableness();
			
			// Track selected avatar
			_selectedAvatarIndex = index;
		}

		private void CreatePlayer()
		{
			PlayerManager.Instance.CreateStoreAndBroadcastNewPlayer(playerNameInput.text, avatars.GetAvatar(_selectedAvatarIndex).Sprite);
			CloseMenuWindow();
		}

		private void OnDestroy()
		{
			EventManager.OnAvatarSelected.Unsubscribe(OnAvatarSelected);
			EventManager.OnAddPlayer.Unsubscribe(ShowCreatePlayerMenu);
			createButton.onClick.RemoveListener(CreatePlayer);
			cancelButton.onClick.RemoveListener(() => gameObject.SetActive(false));
			playerNameInput.onValueChanged.RemoveListener(CheckForValidNameForCreateButton);
		}

		private void SetButtonInteractableness()
		{
			createButton.interactable = _isAvatarSelected && _isNameValid;
		}

		private void CloseMenuWindow()
		{
			gameObject.SetActive(false);
		}
		
	}
}
