namespace mario.Game;

public class GameManager
{
    public GameState State { get; private set; }

    public int Score { get; private set; }

    public int HighScore { get; private set; }

    public void Reset()
    {
        HighScore = Score;
        Score = 0;

        State = GameState.Ready;
    }

    public void Start()
    {
        if (State == GameState.Playing) return;

        State = GameState.Playing;
    }

    public void IncreaseScoreBy(int offset = 1)
    {
        if (State == GameState.Ready) return;

        Score += offset;
    }
}
