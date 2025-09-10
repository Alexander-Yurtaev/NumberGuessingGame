using Moq;
using FluentAssertions;
using NumberGuessingGame.Cli;

namespace NumberGuessingGame.Tests
{
    public class GameTest
    {
        [Theory]
        [InlineData(GameLevel.Easy)]
        [InlineData(GameLevel.Medium)]
        [InlineData(GameLevel.Hard)]
        public void Should_Win_Game_With_Correct_Guess(GameLevel level)
        {
            // Arrange
            var game = SetupGame(level, 5);

            // Act & Assert
            game.CheckNumber(5);
            game.CheckNumberResult.Should().Be(Result.Correct);
            game.CurrentChance.Should().Be(1);
            game.IsStarted.Should().BeFalse();
            game.FinishDate.Should().NotBeNull();
        }

        [Theory]
        [InlineData(GameLevel.Easy)]
        [InlineData(GameLevel.Medium)]
        [InlineData(GameLevel.Hard)]
        public void Should_Greater_With_Incorrect_Guess(GameLevel level)
        {
            // Arrange
            var game = SetupGame(level, 5);

            // Act & Assert
            game.CheckNumber(3);
            game.CheckNumberResult.Should().Be(Result.Greater);
            game.CurrentChance.Should().Be(1);
            game.IsStarted.Should().BeTrue();
            game.FinishDate.Should().BeNull();
        }

        [Theory]
        [InlineData(GameLevel.Easy)]
        [InlineData(GameLevel.Medium)]
        [InlineData(GameLevel.Hard)]
        public void Should_Less_With_Incorrect_Guess(GameLevel level)
        {
            // Arrange
            var mock = new Mock<RandomNumberGenerator>();
            mock
                .Setup(x => x.GetRandomInteger())
                .Returns(5);

            var game = new Game(mock.Object);
            game.Start(level);

            // Act & Assert
            game.CheckNumber(7);
            game.CheckNumberResult.Should().Be(Result.Less);
            game.CurrentChance.Should().Be(1);
            game.IsStarted.Should().BeTrue();
            game.FinishDate.Should().BeNull();
        }

        [Theory]
        [InlineData(GameLevel.Easy)]
        [InlineData(GameLevel.Medium)]
        [InlineData(GameLevel.Hard)]
        public void Should_Lose_Game_When_All_Chances_Used(GameLevel level)
        {
            // Arrange
            int hiddenNumber = 5;
            int maxChances = (int)level;
            var mock = new Mock<RandomNumberGenerator>();
            mock
                .Setup(x => x.GetRandomInteger())
                .Returns(hiddenNumber);

            var game = new Game(mock.Object);
            game.Start(level);

            // Act
            for (int i = 0; i < maxChances; i++)
            {
                game.CheckNumber(hiddenNumber + 1);
            }

            // Assert
            game.IsStarted.Should().BeFalse();
            game.CurrentChance.Should().Be((int)level);
            game.FinishDate.Should().NotBeNull();
        }

        [Theory]
        [InlineData(GameLevel.Easy)]
        [InlineData(GameLevel.Medium)]
        [InlineData(GameLevel.Hard)]
        public void Should_Preserve_State_On_Duplicate_Start_Call(GameLevel level)
        {
            // Arrange
            var game = new Game(new RandomNumberGenerator());
            game.Start(level);
            var startDate = game.StartDate;

            // Act
            game.Start(level);

            // Assert
            game.StartDate.Should().Be(startDate);
        }

        #region Private methods

        private Game SetupGame(GameLevel level, int targetNumber)
        {
            var mock = new Mock<RandomNumberGenerator>();
            mock.Setup(x => x.GetRandomInteger()).Returns(targetNumber);

            var game = new Game(mock.Object);
            game.Start(level);
            
            return game;
        }

        #endregion Private methods
    }
}
