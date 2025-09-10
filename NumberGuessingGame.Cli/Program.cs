namespace NumberGuessingGame.Cli;

public class Program
{
    static void Main()
    {
        var game = new Game(new RandomNumberGenerator());

        PrintGreeting((int)game.Level);
        Console.WriteLine();
        var level = SelectLevel();
        Console.WriteLine();
        game.Start(level);

        while (true)
        {
            Console.WriteLine();
            Console.Write("Enter your guess: ");
            var guessString = Console.ReadLine();
            if (!int.TryParse(guessString, out var guess))
            {
                Console.WriteLine("Please, enter a number.");
                continue;
            }

            if (guess < 1 || guess > 100)
            {
                Console.WriteLine("The guess must be a number between 1 and 100");
                continue;
            }

            game.CheckNumber(guess);
            switch (game.CheckNumberResult)
            {
                case Result.Less:
                    Console.WriteLine($"Incorrect! The number is less than {guess}.");
                    break;
                case Result.Correct:
                    Console.WriteLine($"Congratulations! You guessed the correct number in {game.CurrentChance} attempts in {game.GetDuration():hh\\:mm\\:ss}.");
                    break;
                case Result.Greater:
                    Console.WriteLine($"Incorrect! The number is greater than {guess}.");
                    break;
                default:
                    Console.WriteLine($"Unknown result: {game.CheckNumberResult}");
                    break;
            }

            if (game.IsStarted) continue;

            if (game.CheckNumberResult != Result.Correct)
            {
                Console.WriteLine($"You have exhausted the number of attempts. The hidden number is {game.HiddenNumber}.");
            }
            game.Stop();

            if (ContinueOrExit())
            {
                game.Start(game.Level);
            }
            else
            {
                break;
            }
        }
    }

    static void PrintGreeting(int chances)
    {
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");
        Console.WriteLine($"You have {chances} chances to guess the correct number.");
    }

    static GameLevel SelectLevel()
    {
        while (true)
        {
            Console.WriteLine("Please select the difficulty level:");
            Console.WriteLine("1.Easy(10 chances)");
            Console.WriteLine("2.Medium(5 chances)");
            Console.WriteLine("3.Hard(3 chances)");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            var levelString = Console.ReadLine();
            
            if (!int.TryParse(levelString, out var levelValue))
            {
                Console.WriteLine("You need to enter a number.");
                continue;
            }

            GameLevel level;

            switch (levelValue)
            {
                case 1:
                    level = GameLevel.Easy;
                    break;
                case 2:
                    level = GameLevel.Medium;
                    break;
                case 3:
                    level = GameLevel.Hard;
                    break;
                default:
                    Console.WriteLine("You need to enter a correct number.");
                    continue;
            }

            Console.WriteLine();
            Console.WriteLine($"Great! You have selected the {level} difficulty level.");
            Console.WriteLine("Let's start the game!");

            return level;
        }
    }

    static bool ContinueOrExit()
    {
        Console.WriteLine();
        Console.WriteLine("Do you want to continue?");
        Console.WriteLine("1 - Yes");
        Console.WriteLine("0 - No");
        var answer = Console.ReadLine();
        return answer != "0";
    }
}
