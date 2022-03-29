using System.Collections.Generic;
using UnityEngine;

public class EffectCardPool : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    private readonly List<EffectCard> cards = new List<EffectCard>();

    public EffectCard GetCard()
    {
        foreach (var card in cards)
        {
            if (!card.isActiveAndEnabled)
            {
                card.gameObject.SetActive(true);
                return card;
            }
        }

        var tmp = Instantiate(cardPrefab, transform).GetComponent<EffectCard>();
        cards.Add(tmp);
        return tmp;
    }
}