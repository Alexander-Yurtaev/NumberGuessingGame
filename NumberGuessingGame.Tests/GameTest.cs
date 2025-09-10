using Moq;
using FluentAssertions;
using NumberGuessingGame.Cli;

namespace NumberGuessingGame.Tests
{
    public class GameTest
    {
        [Fact]
        public void Should_Correctly_Handle_Game()
        {
            // Arrange
            var mock = new Mock<RandomNumberGenerator>();
            mock
                .Setup(x => x.GetRandomInteger())
                .Returns(5);

            var game = new Game(mock.Object);

            // Act & Assert
            game.Start(GameLevel.Medium);

            game.CheckNumber(3);
            game.CheckNumberResult.Should().Be(Result.Greater);
            game.CurrentChance.Should().Be(1);
            game.IsStarted.Should().BeTrue();
            game.FinishDate.Should().BeNull();

            game.CheckNumber(6);
            game.CheckNumberResult.Should().Be(Result.Less);
            game.CurrentChance.Should().Be(2);
            game.IsStarted.Should().BeTrue();
            game.FinishDate.Should().BeNull();

            game.CheckNumber(5);
            game.CheckNumberResult.Should().Be(Result.Correct);
            game.CurrentChance.Should().Be(3);
            game.IsStarted.Should().BeFalse();
            game.FinishDate.Should().NotBeNull();
        }

        [Fact]
        public void Should_Lose_Game_When_All_Chances_Used()
        {
            // Arrange
            var mock = new Mock<RandomNumberGenerator>();
            mock
                .Setup(x => x.GetRandomInteger())
                .Returns(5);

            var game = new Game(mock.Object);

            // Act & Assert
            game.Start(GameLevel.Hard);

            game.CheckNumber(3);
            game.CheckNumberResult.Should().Be(Result.Greater);
            game.CurrentChance.Should().Be(1);
            game.IsStarted.Should().BeTrue();
            game.FinishDate.Should().BeNull();

            game.CheckNumber(6);
            game.CheckNumberResult.Should().Be(Result.Less);
            game.CurrentChance.Should().Be(2);
            game.IsStarted.Should().BeTrue();
            game.FinishDate.Should().BeNull();

            game.CheckNumber(4);
            game.CheckNumberResult.Should().Be(Result.Greater);
            game.CurrentChance.Should().Be(3);
            game.IsStarted.Should().BeFalse();
            game.FinishDate.Should().NotBeNull();
        }
    }
}
