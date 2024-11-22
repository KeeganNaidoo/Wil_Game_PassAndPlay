using UnityEngine;

namespace WilGame
{
	[System.Serializable]
	public class Avatar
	{
		public int Index;
		public Sprite Sprite;
		[HideInInspector] public bool IsUsed;
	}
}
