# Snakes and Ladder

This is a quick attempt to have fun during an airplane flight. It's based on the Agile Kata excercise and built completely offline (during flights) with the only exception of making sure that NuGet packages are downloaded before I take off.

## Basic Design

My thinking for design is to sort get ready for later, when I _want_ to implement an Actor Based Framework as well. With this in mind, I designed a `Game` object that holds the state of the game, and also a _reference_ of players that are playing the game. All interactions happen with this object, or an instance of it.

### Dice Rolling and Moves

For dice rolling, I thought about having a simple integer passed in as a parameter, but then figured that's "easily bypassable" so I decided to introduce an `IDice` interface that represents dice. The upside here is that because of this I can actually introduce different types of dice later on, to make the game more fun (i.e. a dice with a _break_ in it, where the user needs to take a break).

The dice, when rolled, generates an `IDiceRoll`. I've created `IDiceRoll` just because I feel it's nicer to ensure that there was actually a dice roll that happened, that moved. For testing, we can still mock it, but later on, this will help me code the game with a bit more structure.

For each dice roll, there is usually a move associated with it. The move can be valid or invalid, depending on the position of the player. This was a late addition to the logic, but I decided that `PlayTurn` method will return a `bool` indicating if the move was valid or not. While there is also an event that is raised in case of an invalid move, this provides an easy way to check.

### Players

Players are added to the game by invoking `game.CreatePlayer(name)`. This way, the game always monitors the creation of the players that join it, even though it might accept some additional parameters later on (think color, rank, gamer id, depending on how the game evolves).

Each move of the game is triggered by also passing a reference to the player that has made the move. I did briefly consider doing it from the player itself, but I decided against it, because I wanted the game to contain the relevant state. Worst case, this can still be refactored later, if needed.

### Events

#### Game Won

The event is triggered, fairly obviously, when the game is won. The event will contain the reference to the player that won the game.

> TODO: there's an obvious need to have a _player rank_ at this point, and it might make sense to introduce that at a later stage.

#### Invalid Move

As the name implies, this event is triggered if the move is invalid, for example if the dice rolls too high a number, considering the player's position. This usually happens when a player almost reached the end of the game, i.e. is on field 97 on a 100 field board, and rolls a 4. 