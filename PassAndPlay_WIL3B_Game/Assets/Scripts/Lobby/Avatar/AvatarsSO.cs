using System;
using System.Collections.Generic;
using UnityEngine;


namespace WilGame
{
	
	[CreateAssetMenu(menuName = "AvatarsSO", fileName = "Scriptable Objects/Avatars")]
	public class AvatarsSO : ScriptableObject
	{
		[SerializeField] private List<Avatar> avatars;
		
		public int Count => avatars.Count;
		public Avatar GetAvatar(int index) => avatars[index];

		public void ResetAvatarUsage()
		{
			foreach (var avatar in avatars)
			{
				avatar.IsUsed = false;
			}
		}

		public Avatar GetAvatar(Sprite sprite)
		{
			return avatars.Find(x => x.Sprite == sprite);
		}
	}
}
