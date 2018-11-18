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

        public override bool Equals(object obj) {
            var px = obj as Player;
            if(px == null) return false;
            return string.Equals(px.Name, this.Name);
        }
    }
}