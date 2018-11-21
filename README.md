# Snakes and Ladder

This is a quick attempt to have fun during one or multiple airplane flight(s). It's based on the Agile Kata excercise and built completely offline (during flights) with the only exception of making sure that NuGet packages are downloaded before I take off. I usually push the code back up to GitHub when I land.

## Basic Design

My thinking for design was to start simple, despite the fact I _really want_ to implement an Actor Based Framework in the future, just to test some things out. However, having been burned by this before, I decided to keep my architecture as simple as possible. With this in mind, I designed a `Game` object that holds the state of the game, and also a _reference_ of players that are playing the game. All interactions happen with this object, or an instance of it.

### Moves and Dice Rolling

To initiate a move, one must call `game.PlayTurn(Player)`. This call, at the moment is pretty simple, simply calling the dice object and rolling it, and then initiating the move of a player.

> In the future (i.e. for Feature 3 and 4), it might make more sense to have a `PlayTurn` which also looks at which player is next based on game play. For testability, however, this makes it nice and easy, and doesn't seem to be overly horrible.

For dice rolling, I thought about having a simple integer passed in as a parameter, but then figured that's "easily bypassable". For that reason, and to make it testable, I decided to introduce an `IDice` interface that represents dice. The upside here is that because of this I can actually introduce different types of dice later on, to make the game more fun (i.e. a dice with a _break_ in it, where the user needs to take a break).

The dice, when rolled, generates an `IDiceRoll`. I've created `IDiceRoll` just because I feel it's nicer to ensure that there was actually a dice roll that happened, that moved. For testing, we can still mock it, but later on, this will help me code the game with a bit more structure.

As hinted, each move _initiates_ a dice roll. The move can then be valid or invalid, depending on the position of the player. This was a late addition to the logic, but I decided that `PlayTurn` method will return a `bool` indicating if the move was valid or not. While there is also an event that is raised in case of an invalid move, this provides an easy way to check.

> In the future, this would probably be a good candidate to replace with a `MoveDescriptor`. This might be especially handy in Feature 2 implementation, where moves will not only be valid/invalid but might also contain a jump/fall.

### Players

Players are added to the game by invoking `game.CreatePlayer(name)`. This way, the game always monitors the creation of the players that join it, even though it might accept some additional parameters later on (think color, rank, gamer id, depending on how the game evolves).

> Each move of the game is triggered by also passing a reference to the player that has made the move. I did briefly consider doing it from the player itself, but I decided against it, because I wanted the game to contain the relevant state. Worst case, this can still be refactored later, if needed.

### Events

At the moment, game events are implemented as actual events. While this is a bit more difficult to test, I feel it makes more sense as it represents the real-world more closely. Doing this also avoids requiring the caller to check state (i.e. if the game is still active or not, or if the player won). This also eases the potential for cheating code.

#### Game Won

The event is triggered, fairly obviously, when the game is won. The event will contain the reference to the player that won the game.

> TODO: there's an obvious need to have a _player rank_ at this point, and it might make sense to introduce that at a later stage.

#### Invalid Move

As the name implies, this event is triggered if the move is invalid, for example if the dice rolls too high a number, considering the player's position. This usually happens when a player almost reached the end of the game, i.e. is on field 97 on a 100 field board, and rolls a 4.

## Thoughts when flying

This section just contains a list of thoughts that came through my head as I was flying. I'll remove them from the document as I compelte more code.

- The other option here, would be to design the players to actually "play" the game, and get invoked when it's their turn to play the game. So, the game would relinquish control to the player, to then make the next move. For ease of coding, I've opted for the simpler option of letting the caller/test dictate the game. Maybe for v2, I'll refactor it. :-)6