namespace NumberGuessingGame.Cli;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    public virtual int GetRandomInteger()
    {
        return Random.Shared.Next(1, 100);
    }
}