using System;
using System.Collections.Generic;
using UnityEngine;
using WilGame.Players;


namespace WilGame
{
	
	public class AvatarSelectionGroup : MonoBehaviour
	{
		[SerializeField] private AvatarSelectionItem avatarSelectionItemPrefab;
		private List<AvatarSelectionItem> _avatarSelectionItems;
		[SerializeField] private AvatarsSO avatars;
		private int _selectedAvatarIndex = -1;

		private void Awake()
		{
			EventManager.OnAvatarSelected.Subscribe(OnAvatarSelected);
			EventManager.OnCreatePlayer.Subscribe(OnPlayerCreated);
			EventManager.OnRemovePlayer.Subscribe(MakeAvatarAvailable);
			
			// Create avatar selection items
			_avatarSelectionItems = new List<AvatarSelectionItem>();
			for (int i = 0; i < avatars.Count; i++)
			{
				_avatarSelectionItems.Add(Instantiate(avatarSelectionItemPrefab, transform));
				_avatarSelectionItems[i].AssignAvatar(i, avatars.GetAvatar(i).Sprite);
			}
		}

		private void MakeAvatarAvailable(int playerId)
		{
			Sprite targetAvatarImage = PlayerManager.Instance.GetPlayer(playerId).Avatar;
			avatars.GetAvatar(targetAvatarImage).IsUsed = false;
			int index = avatars.GetAvatar(targetAvatarImage).Index;
			_avatarSelectionItems[index].SetAvailable();
		}

		private void OnPlayerCreated(PlayerData player)
		{
			// set selected avatar as used
			avatars.GetAvatar(_selectedAvatarIndex).IsUsed = true;
			_avatarSelectionItems[_selectedAvatarIndex].SetUnavailable();
			
			// assign avatar to player data
			player.Avatar = avatars.GetAvatar(_selectedAvatarIndex).Sprite;
			
			// deselect avatar
			_avatarSelectionItems[_selectedAvatarIndex].DeselectAvatar();
			_selectedAvatarIndex = -1;
		}

		private void OnAvatarSelected(int index)
		{
			if (_selectedAvatarIndex != -1) // if another avatar was selected, deselect it
			{
				_avatarSelectionItems[_selectedAvatarIndex].DeselectAvatar();
			}
			_selectedAvatarIndex = index;
		}

		private void OnDestroy()
		{
			EventManager.OnAvatarSelected.Unsubscribe(OnAvatarSelected);
			EventManager.OnCreatePlayer.Unsubscribe(OnPlayerCreated);
			EventManager.OnRemovePlayer.Unsubscribe(MakeAvatarAvailable);
		}
		
		public void ResetGroup()
		{
			for (int i = 0; i < _avatarSelectionItems.Count; i++)
			{
				_avatarSelectionItems[i].ResetItem();
			}
			avatars.ResetAvatarUsage();
		}
		
	}
}
