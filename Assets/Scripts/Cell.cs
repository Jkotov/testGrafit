using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Card Card
    {
        get;
        set;
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

    private void OnMouseUpAsButton()
    {
        grid.CellClicked(Pos);
    }
}
