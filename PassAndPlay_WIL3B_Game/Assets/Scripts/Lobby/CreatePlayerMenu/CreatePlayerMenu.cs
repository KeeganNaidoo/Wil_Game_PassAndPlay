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
		private bool _isAvatarSelected = false; // can't create player if no avatar is selected
		[SerializeField] private int playerNameCharacterLimit = 12;
		
		private void Start()
		{
			EventManager.OnAvatarSelected.Subscribe(TrackSelectedAvatar);
			EventManager.OnAddPlayer.Subscribe(ShowCreatePlayerMenu);
			createButton.onClick.AddListener(CreatePlayer);
			cancelButton.onClick.AddListener(() =>gameObject.SetActive(false));
			playerNameInput.characterLimit = playerNameCharacterLimit;
			gameObject.SetActive(false);
		}

		private void ShowCreatePlayerMenu()
		{
			gameObject.SetActive(true);
			playerNameInput.text = "";
		}

		private void TrackSelectedAvatar(int index)
		{
			_isAvatarSelected = index != -1;
		}

		private void CreatePlayer()
		{
			if (_isAvatarSelected == false) return;
			if (playerNameInput.text == "") return;
			EventManager.OnCreatePlayer.Invoke(new PlayerData(playerNameInput.text));
			gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			EventManager.OnAvatarSelected.Unsubscribe(TrackSelectedAvatar);
			EventManager.OnAddPlayer.Unsubscribe(ShowCreatePlayerMenu);
			createButton.onClick.RemoveListener(CreatePlayer);
			cancelButton.onClick.RemoveListener(() => gameObject.SetActive(false));
		}
		
	}
}
