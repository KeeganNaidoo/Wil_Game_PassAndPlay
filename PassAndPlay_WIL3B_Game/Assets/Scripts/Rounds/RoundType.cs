namespace WilGame.Rounds
{
    public class RoundType
    {
        public string Name { get; }

        public RoundType(string name)
        {
            Name = name;
        }
        public int AnswerCharacterLimit { get; set; }
        
    }
}