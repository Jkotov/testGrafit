using System;
using System.Collections;
using UnityEngine;

public class PlayerCard : Card
{
    public override int Hp
    {
        get => hp;
        set
        {
            hp = value;
            hpText.text = hp.ToString();
            if (hp <= 0)
            {
                Destroy();
            }
        }
    }

    [SerializeField] private protected new int hp;

    private protected override void Awake()
    {
        base.Awake();
        hpText.text = hp.ToString();
    }

    public override void Destroy()
    {
        base.Destroy();
        GameManager.Instance.GameOver();
    }
}