using TMPro;
using UnityEngine;


public class DifficultyLevel : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private int levelOnStart;
    [SerializeField] private int scoreForLevel;
    public int Level
    {
        get => level;
        private set
        {
            if (level != value)
            {
                level = value;
                if (text != null)
                    text.text = "Level: " + level.ToString();
            }
        }
    }
    private int level;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        Level = levelOnStart;
        score.ScoreChanged += UpdateLevel;
    }

    private void UpdateLevel(int scoreValue)
    {
        Level = scoreValue / scoreForLevel + levelOnStart;
    }
}
