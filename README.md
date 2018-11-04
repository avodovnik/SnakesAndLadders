# Snakes and Ladder

This is a quick attempt to have fun during an airplane flight. It's based on the Agile Kata excercise and built completely offline (during flights) with the only exception of making sure that NuGet packages are downloaded before I take off.

## Basic Design
My thinking for design is to sort get ready for later, when I _want_ to implement an Actor Based Framework as well.

Classes:

* `Position` class is there as I want to be able to, in the future, add some additional logic to the position and this provides an easy way of doing it, without introducing too much complexity.

* I've created `IDiceRoll` just because I feel it's nicer to ensure that there was actually a dice roll that happened, that moved. For testing, we can still mock it, but later on, this will help me code the game with a bit more structure.