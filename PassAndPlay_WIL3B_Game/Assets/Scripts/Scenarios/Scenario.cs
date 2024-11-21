namespace WilGame.Scenarios
{
    public struct Scenario
    {
        public int Id;
        public string Text;
        public int Score;
        
        public Scenario(int id, string text, int score = 100)
        {
            Id = id;
            Text = text;
            Score = score;
        }
    }
}