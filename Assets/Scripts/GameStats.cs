using UnityEngine;

public class GameStats
{
    static GameStats()
    {
    }

    private GameStats()
    {
    }
    
    public static GameStats Instance { get; } = new GameStats();
    public int Score
    {
        get => score;
        private set
        {
            score = value;
            ScoreChanged?.Invoke(score);
        }
    }
    public int Level
    {
        get => level;
        private set
        {
            level = value;
            LevelChanged?.Invoke(level);
        }
    }
    public delegate void ScoreHandle(int score);
    public event ScoreHandle ScoreChanged;
    public delegate void LevelHandle(int level);
    public event LevelHandle LevelChanged;

    private int score;
    private int level;
    private int levelOnStart;
    private int scoreForLevel;

    public void AddScore()
    {
        Score++;
        UpdateLevel(Score);
    }
    
    public void ResetStats(int levelOnStart, int scoreForLevel)
    {
        Score = 0;
        this.levelOnStart = levelOnStart;
        Level = levelOnStart;
        this.scoreForLevel = scoreForLevel;
    }
    
    public void SaveRecord()
    {
        if (PlayerPrefs.GetInt("score", 0) < Score)
            PlayerPrefs.SetInt("score", Score);
    }
    
    private void UpdateLevel(int scoreValue)
    {
        var newLevel =  scoreValue / scoreForLevel + levelOnStart;
        if (Level != newLevel)
            Level = newLevel;
    }
}