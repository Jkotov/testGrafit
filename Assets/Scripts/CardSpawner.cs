using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private HpChangeCardPool healCardPool;
    [SerializeField] private HpChangeCardPool damageCardPool;
    [SerializeField] private GameObject playerCardPrefab;
    [SerializeField] private DifficultyLevel difficultyLevel;
    [SerializeField] private float damageCardChancePerDifficultyLevel;
    [SerializeField] private float maxDamageCardChance;
    
    private float DamageCardChance()
    {
        var chance = damageCardChancePerDifficultyLevel * difficultyLevel.Level;
        return chance < maxDamageCardChance ? chance : maxDamageCardChance;
    }

    public void SpawnHpCard(CardGrid grid, Vector2Int pos)
    {
        var rnd = Random.Range(0f, 1f);
        var hp = 1 + Random.Range(0, difficultyLevel.Level + 1);
        HpChangeCard card;
        if (DamageCardChance() < rnd)
        {
            card = healCardPool.GetCard();
            card.Hp = hp;
        }
        else
        {
            card = damageCardPool.GetCard();
            card.Hp = -hp;
        }
        card.transform.position = grid.cells[pos.x, pos.y].transform.position;
        card.SpawnAnimation();
        grid.cells[pos.x, pos.y].Card = card;
    }

    public void SpawnPlayerCard(CardGrid grid, Vector2Int pos)
    {
        var player = Instantiate(playerCardPrefab, grid.cells[pos.x, pos.y].transform.position, Quaternion.identity).GetComponent<Card>();
        grid.cells[pos.x, pos.y].Card = player;
    }
}