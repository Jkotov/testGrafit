using System;

public class HpChangeCard : Card
{
    public override int Hp
    {
        get => hp;
        set
        {
            hp = value;
            hpText.text = Math.Abs(hp).ToString();
        }
    }
}