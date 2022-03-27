using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public virtual int Hp
    {
        get => hp;
        set
        {
            hp = value;
            hpText.text = hp.ToString();
        }
    }

    private protected int hp;
    [SerializeField] private protected TextMeshPro hpText;
    [SerializeField] private float cardAnimationTime;
    [SerializeField] private Vector3 minScale;
    private Vector3 maxScale;

    private protected virtual void Awake()
    {
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
