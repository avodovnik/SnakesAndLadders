namespace SnakesAndLadders.Contracts
{
    public class Player 
    {
        public Player(string name)
        {
            this.Name = name;
            this.Position = new Position(1);
        }

        public string Name { get; }

        public Position Position { get; set; }
    }
}