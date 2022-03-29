using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TmpguiVisualizer : MonoBehaviour, ITextVisualizer
    {
        private TextMeshProUGUI textMeshProUGUI;
    
        public void UpdateText(string text)
        {
            if (textMeshProUGUI == null)
                textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            textMeshProUGUI.text = text;
        }
    }
}