using System;
using System.Collections.Generic;
using UnityEngine;


namespace WilGame
{
	
	public class AvatarSelectionGroup : MonoBehaviour
	{
		[SerializeField] private List<AvatarSelectionItem> avatarSelectionItems;
		[SerializeField] private AvatarsSO avatars;

		private void OnEnable()
		{
			EventManager.OnAvatarSelected.Subscribe(OnAvatarSelected);
		}

		private void OnAvatarSelected(int index)
		{
			
		}

		private void OnDisable()
		{
			
		}
	}
}
