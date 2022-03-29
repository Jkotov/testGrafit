using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshPro))]
    public class TmpVisualizer : MonoBehaviour, ITextVisualizer
    {
        private TextMeshPro textMeshPro;
    
        public void UpdateText(string text)
        {
            if (textMeshPro == null)
                textMeshPro = GetComponent<TextMeshPro>();
            textMeshPro.text = text;
        }
    }
}