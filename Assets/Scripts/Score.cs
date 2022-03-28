using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int ScoreValue
    {
        get => score;
        set
        {
            score = value;
            if (text != null)
                text.text = "Score: " + score.ToString();
            ScoreChanged?.Invoke(score);
            GameManager.Instance.score = score;
        }
    }
    
    public delegate void ScoreHandle(int score);
    public event ScoreHandle ScoreChanged;
    
    private int score;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
}
