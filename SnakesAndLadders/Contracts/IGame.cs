namespace SnakesAndLadders.Contracts
{
    /// Defines the main interactions possible to the game. The implmentation of
    /// this interface should ideally also hold the logic.
    public interface IGame
    {
        // creates a new player with a given name
        Player CreatePlayer(string name);
    }    
}