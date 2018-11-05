using System;
using Xunit;
using Moq;
using SnakesAndLadders.Contracts;

namespace SnakesAndLadders.Tests
{
    public class GameTests
    {
        [Fact]
        public void PlayersAddedAlwaysStartOnFirstPosition()
        {
            var game = new Game(null);

            // when we add a player to the game
            var player = game.CreatePlayer("Anze");

            // the player is automatically placed on position 1
            Assert.Equal(1, player.Position);
        }

        [Theory]
        [InlineData(10, 11)]
        [InlineData(50, 51)]
        [InlineData(101, 1)]
        public void PlayerCanMoveAcrossTheBoard(int diceRoll, int expectedPosition)
        {
            var rollMock = new Mock<IDiceRoll>();
            rollMock.SetupGet(x => x.Roll).Returns(diceRoll);

            var diceMock = new Mock<IDice>();
            diceMock.Setup(x => x.Roll()).Returns(rollMock.Object);

            //Given
            var game = new Game(diceMock.Object);
            var player = game.CreatePlayer("Test Player");

            //When
            game.PlayTurn(player); 

            //Then
            Assert.Equal(expectedPosition, player.Position);
        }
    }
}
