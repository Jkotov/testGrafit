using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private EffectCardPool healCardPool;
    [SerializeField] private EffectCardPool damageCardPool;
    [SerializeField] private GameObject playerCardPrefab;
    [SerializeField] private float damageCardChancePerDifficultyLevel;
    [SerializeField] private float maxDamageCardChance;
    
    public void SpawnEffectCard(CardGrid grid, Vector2Int pos)
    {
        var hp = 1 + Random.Range(0, GameStats.Instance.Level + 1);
        EffectCard card;
        if (IsSpawnDamageCard())
        {
            card = damageCardPool.GetCard();
            card.Hp = -hp;
        }
        else
        {
            card = healCardPool.GetCard();
            card.Hp = hp;
        }
        card.transform.position = grid.cells[pos.x, pos.y].transform.position;
        card.SpawnAnimation();
        grid.cells[pos.x, pos.y].Card = card;
    }

    public PlayerCard SpawnPlayerCard(CardGrid grid, Vector2Int pos)
    {
        var player = Instantiate(playerCardPrefab, grid.cells[pos.x, pos.y].transform.position, Quaternion.identity).GetComponent<PlayerCard>();
        player.SpawnAnimation();
        grid.cells[pos.x, pos.y].Card = player;
        return player;
    }
    
    private bool IsSpawnDamageCard()
    {
        var chance = damageCardChancePerDifficultyLevel * GameStats.Instance.Level;
        chance = chance < maxDamageCardChance ? chance : maxDamageCardChance;
        var rnd = Random.Range(0f, 1f);
        return chance > rnd;
    }
}