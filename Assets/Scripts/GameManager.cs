using System.Collections;
using System.Threading.Tasks;
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
    private int msBeforeGameOverSceneLoad;

    public void StartGame(float secondsBeforeGameOverSceneLoad)
    {
        IsGameOver = false;
        msBeforeGameOverSceneLoad = (int)(secondsBeforeGameOverSceneLoad * 1000);
    }
    
    public void GameOver()
    {
        IsGameOver = true;
        GameStats.Instance.SaveRecord();
        Debug.Log("GameOver");
        LoadGameOverSceneWithTimeout(msBeforeGameOverSceneLoad);
    }

    private async void LoadGameOverSceneWithTimeout(int timeout)
    {
        await Task.Delay(timeout);
        SceneManager.LoadScene("GameOver");
    }
}
