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
		
		public PlayerData(string name)
		{
			Id = 0;
			Name = name;
			Avatar = null;
			Score = 0;
			Answer = "";
			TurnOrder = Id;
			Status = PlayerStatus.Waiting;
		}

		public void SetId(int id)
		{
			Id = id;
		}
	}
	
	
}
