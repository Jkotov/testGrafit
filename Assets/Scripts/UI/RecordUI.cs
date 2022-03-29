using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(ITextVisualizer))]
    public class RecordUI : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<ITextVisualizer>().UpdateText("Record: " + PlayerPrefs.GetInt("score", 0).ToString());
        }
    }
}
