using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int score;

    public void GameOver()
    {
        IsGameOver = true;
        Debug.Log("GameOver");
        if (PlayerPrefs.GetInt("score", 0) < score)
            PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene("GameOver");
    }
}
