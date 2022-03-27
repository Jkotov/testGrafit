using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Card Card
    {
        get => card;
        set
        {
            if (card != null && value != null)
                card.gameObject.SetActive(false);
            card = value;
        }
    }

    public CardGrid Grid
    {
        set => grid ??= value;
    }
    public Vector2Int Pos
    {
        get => pos.GetValueOrDefault();
        set => pos ??= value;
    }

    private CardGrid grid;
    private Vector2Int? pos;
    private Card card;

    private void OnMouseUpAsButton()
    {
        grid.CellClicked(Pos);
    }
}
