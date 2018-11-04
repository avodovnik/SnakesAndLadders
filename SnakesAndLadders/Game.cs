using System.Collections.Generic;
using SnakesAndLadders.Contracts;

public class Game : IGame
{
    // TODO: this would be nicer as a wider config, but it'll do for now
    private const int BoardLength = 100; 

    private readonly IDice _dice;
    private List<Player> _players;

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

    public void PlayTurn(Player player) {
        // the game won't be fun if there's another player trying to make their turn
        if(!_players.Contains(player)) 
        {
            throw new System.Exception("Given player is not a member of this game.");
        }

        // but, let's roll the dice
        var diceRoll = _dice.Roll();

        // and make the player move
        this.MovePlayer(player, diceRoll);
    }

    private void MovePlayer(Player player, IDiceRoll roll) {
        // get the player's position
        var position = player.Position;
        // see if we can move him
        var newPosition = position.Location + roll.Roll;
        if(newPosition > BoardLength) {
            // TODO: trigger invalid move event
        }

        // and if we can, check for events
        if(newPosition == BoardLength) {
            // TODO: trigger game won event!
        }

        // update the player's position
        player.Position = new Position(newPosition);
    }
}