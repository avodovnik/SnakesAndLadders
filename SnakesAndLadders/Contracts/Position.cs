namespace SnakesAndLadders.Contracts 
{
    public struct Position 
    {
        public Position(int position)
        {
            this.Location = position;
        }
        
        public int Location { get; }
    }
}