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
            var diceMock = new Mock<IDice>();
            // diceMock.Setup(x => x.Roll().Return(new Mock<IDiceRoll>().Setup))
//             var mock = new Mock<IFoo>();
// mock.Setup(foo => foo.DoSomething("ping")).Returns(true);

            var game = new Game();
            // when we add a player to the game
            // the player is automatically placed on position 1
        }
    }
}
