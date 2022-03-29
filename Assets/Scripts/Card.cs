using System.Collections;
using DG.Tweening;
using TMPro;
using UI;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    [SerializeField] private protected float cardAnimationTime;
    [SerializeField] private Vector3 minScale;
    [SerializeField] private GameObject textBox;
    private protected ITextVisualizer textVisualizer;
    private Vector3 maxScale;
    
    private protected virtual void Awake()
    {
        textVisualizer = textBox.GetComponent<ITextVisualizer>();
        maxScale = transform.localScale;
    }
    
    public void MoveAnimation(Vector3 pos)
    {
        transform.DOMove(pos, cardAnimationTime);
    }

    public virtual void Destroy()
    {
        StartCoroutine(DestroyTimeout());
    }

    public void SpawnAnimation()
    {
        transform.localScale = minScale;
        transform.DOScale(maxScale, cardAnimationTime);
    }

    private IEnumerator DestroyTimeout()
    {
        yield return transform.DOScale(minScale, cardAnimationTime).WaitForCompletion();
        gameObject.SetActive(false);
    }
}
