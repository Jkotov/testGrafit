using System;
using UnityEngine;

public class CardGrid : MonoBehaviour
{
    public Cell[,] cells;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellWidthOffset;
    [SerializeField] private float cellHeightOffset;
    [SerializeField] private GameObject cell;
    [SerializeField] private Vector2Int playerPos;
    [SerializeField] private CardSpawner cardSpawner;
    [SerializeField] private Score score;
    private bool CanPlayerMove(Vector2Int pos) => Math.Abs(pos.x - playerPos.x) + Math.Abs(pos.y - playerPos.y) == 1 &&
                                                  !GameManager.Instance.IsGameOver;
    
    public void CellClicked(Vector2Int pos)
    {
        if (!CanPlayerMove(pos))
            return ;
        MovePlayerCard(pos);
    }
    
    private void Awake()
    {
        CreateGrid();
    }
    
    private void CreateGrid()
    {
        cells = new Cell[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var tmp = Instantiate(cell,
                    transform.position + Vector3.right * cellWidthOffset * i + Vector3.up * cellHeightOffset * j,
                    Quaternion.identity, transform);
                cells[i, j] = tmp.GetComponent<Cell>();
                cells[i, j].Pos = Vector2Int.right * i + Vector2Int.up * j;
                if (cells[i, j].Pos != playerPos)
                    SpawnHpCard(cells[i, j].Pos);
                else
                    cardSpawner.SpawnPlayerCard(this, cells[i, j].Pos);
                cells[i, j].Grid = this;
            }
        }
    }

    private void SpawnHpCard(Vector2Int pos)
    {
        cardSpawner.SpawnHpCard(this, pos);
    }

    private void DestroyCard(Vector2Int pos)
    {
        cells[pos.x, pos.y].Card.Destroy();
    }

    private void MovePlayerCard(Vector2Int pos)
    {
        cells[playerPos.x, playerPos.y].Card.Hp += cells[pos.x, pos.y].Card.Hp;
        MoveCard(playerPos, pos);
        playerPos = pos;
        score.ScoreValue++;
    }

    private void MoveCard(Vector2Int pos, Vector2Int newPos)
    {
        DestroyCard(newPos);
        cells[newPos.x, newPos.y].Card = cells[pos.x, pos.y].Card;
        cells[pos.x, pos.y].Card.MoveAnimation(cells[newPos.x, newPos.y].transform.position);
        cells[pos.x, pos.y].Card = null;
        SpawnHpCard(pos);
    }
}
