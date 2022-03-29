using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(ITextVisualizer))]
    public class ScoreUI : MonoBehaviour
    {
        private ITextVisualizer text;

        private void Awake()
        {
            text = GetComponent<ITextVisualizer>();
            UpdateScore(GameStats.Instance.Score);
            GameStats.Instance.ScoreChanged += UpdateScore;
        }
    
        private void UpdateScore(int score)
        {
            text.UpdateText("Score: " + score);
        }

        private void OnDestroy()
        {
            GameStats.Instance.ScoreChanged -= UpdateScore;
        }
    }
}
