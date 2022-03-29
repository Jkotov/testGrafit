using System;
using System.Collections;
using UnityEngine;

public class PlayerCard : Card
{
    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
            textVisualizer?.UpdateText(hp.ToString());
            if (hp <= 0)
            {
                Destroy();
            }
        }
    }

    [SerializeField] private int hp;

    private void Start()
    {
        textVisualizer?.UpdateText(hp.ToString());
    }

    public override void Destroy()
    {
        base.Destroy();
        GameManager.Instance.GameOver();
    }
}