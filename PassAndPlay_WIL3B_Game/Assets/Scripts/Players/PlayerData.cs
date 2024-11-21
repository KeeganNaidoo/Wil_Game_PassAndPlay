using UnityEngine;

namespace WilGame.Players
{
	
	public struct PlayerData
	{
		public int Id;
		public string Name;
		public Sprite Avatar;
		public int Score;
		public string Answer;
		public int TurnOrder;
		public PlayerStatus Status;
		
		public PlayerData(int id, string name, Sprite avatar, int turnOrder)
		{
			Id = id;
			Name = name;
			Avatar = avatar;
			Score = 0;
			Answer = "";
			TurnOrder = turnOrder;
			Status = PlayerStatus.Waiting;
		}
	}
	
	
}
