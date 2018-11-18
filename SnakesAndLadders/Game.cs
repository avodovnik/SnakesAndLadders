using System.Collections.Generic;
using SnakesAndLadders.Contracts;

public class Game : IGame
{
    // TODO: this would be nicer as a wider config, but it'll do for now
    private const int BoardLength = 100;

    private readonly IDice _dice;
    private List<Player> _players = new List<Player>();

    public Game(IDice dice)
    {
        this._dice = dice;
        // initialize a new board  
    }

    public Player CreatePlayer(string name)
    {
        var player = new Player(name);
        this._players.Add(player);
        return player;
    }

    public bool PlayTurn(Player player)
    {
        // the game won't be fun if there's another player trying to make their turn
        if (!_players.Contains(player))
        {
            throw new System.Exception("Given player is not a member of this game.");
        }

        // but, let's roll the dice
        var diceRoll = _dice.Roll();

        // and make the player move
        return this.MovePlayer(player, diceRoll);
    }

    private bool MovePlayer(Player player, IDiceRoll roll)
    {
        // check if the game is still playable
        if (!this.IsGameActive)
        {
            // TODO: do we throw an invalid move here?
            return false;
        }

        // get the player's position
        var position = player.Position;
        // see if we can move him
        var newPosition = position.Location + roll.Roll;
        if (newPosition > BoardLength)
        {
            OnInvalidMove?.Invoke(player, roll.Roll, newPosition);
            return false;
        }

        // and if we can, check for events
        if (newPosition == BoardLength)
        {
            OnGameWon?.Invoke(player);
            IsGameActive = false;
        }

        // update the player's position
        player.Position = new Position(newPosition);
        return true;
    }

    public delegate void GameWon(Player player);
    public delegate void InvalidMove(Player player, int stepsWanted, int wouldBePosition);

    /// Fires when the game is won by a player
    public event GameWon OnGameWon;

    // Fires when a player makes a move that is invalid
    // or would cause an invalid position on the board
    public event InvalidMove OnInvalidMove;

    public bool IsGameActive { get; set; } = true;
}