using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(ITextVisualizer))]
    public class LevelUI : MonoBehaviour
    {
        private ITextVisualizer text;

        private void Awake()
        {
            text = GetComponent<ITextVisualizer>();
            UpdateLevel(GameStats.Instance.Level);
            GameStats.Instance.LevelChanged += UpdateLevel;
        }

        private void UpdateLevel(int level)
        {
            text.UpdateText("Level: " + level);
        }

        private void OnDestroy()
        {
            GameStats.Instance.LevelChanged -= UpdateLevel;
        }
    }
}
