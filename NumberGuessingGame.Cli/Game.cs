namespace NumberGuessingGame.Cli;

public class Game
{
    private readonly IRandomNumberGenerator _numberGenerator;
    private GameLevel _level;
    private DateTime _startDate;
    private DateTime? _finishDate;
    private int _hiddenNumber;
    private int _currentChance;

    public GameLevel Level { get => _level; init => _level = value; }
    public DateTime StartDate { get => _startDate; init => _startDate = value; }
    public DateTime? FinishDate { get => _finishDate; private set => _finishDate = value; }
    public int HiddenNumber { get => _hiddenNumber; init => _hiddenNumber = value; }
    public int CurrentChance { get => _currentChance; private set => _currentChance = value; }

    public bool IsStarted { get; private set; }
    public Result CheckNumberResult { get; private set; }

    public Game(IRandomNumberGenerator numberGenerator)
    {
        _numberGenerator = numberGenerator;
    }

    public void Start(GameLevel level)
    {
        if (IsStarted) return;

        _level = level;
        _startDate = DateTime.Now;
        _finishDate = null;
        _hiddenNumber = _numberGenerator.GetRandomInteger();
        _currentChance = 0;
        IsStarted = true;
        CheckNumberResult = Result.Less;
    }

    public void Stop()
    {
        if (!IsStarted) return;

        IsStarted = false;
        FinishDate = DateTime.Now;
    }

    public void CheckNumber(int number)
    {
        CurrentChance++;

        if (HiddenNumber == number)
        {
            Stop();
            CheckNumberResult = Result.Correct;
        }
        else if (HiddenNumber > number)
        {
            CheckNumberResult = Result.Greater;
        }
        else
        {
            CheckNumberResult = Result.Less;
        }

        if (!HasNextChance())
        {
            Stop();
        }
    }

    public bool HasNextChance()
    {
        var maxChances = (int)Level;
        return IsStarted && CurrentChance < maxChances;
    }

    public TimeSpan GetDuration()
    {
        if (!IsStarted && FinishDate.HasValue)
        {
            return FinishDate.Value - StartDate;
        }

        return TimeSpan.Zero;
    }
}