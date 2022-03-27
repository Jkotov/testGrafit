using System.Collections.Generic;
using UnityEngine;

public class HpChangeCardPool : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    private readonly List<HpChangeCard> cards = new List<HpChangeCard>();

    public HpChangeCard GetCard()
    {
        foreach (var card in cards)
        {
            if (!card.isActiveAndEnabled)
            {
                card.gameObject.SetActive(true);
                return card;
            }
        }

        var tmp = Instantiate(cardPrefab).GetComponent<HpChangeCard>();
        cards.Add(tmp);
        return tmp;
    }
}