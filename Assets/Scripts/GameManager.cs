using UnityEngine;

public class GameManager
{
    static GameManager()
    {
    }

    private GameManager()
    {
    }

    public static GameManager Instance { get; } = new GameManager();
    public bool IsGameOver { get; private set; }

    public void GameOver()
    {
        IsGameOver = true;
        Debug.Log("GameOver");
    }
}
