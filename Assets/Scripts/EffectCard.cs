using System;

public class EffectCard : Card, IEffectOnPlayer
{
    public int Hp
    {
        set
        {
            hp = value;
            textVisualizer?.UpdateText(Math.Abs(hp).ToString());
        }
    }

    private int hp;
    
    public void Effect(ref PlayerCard playerCard)
    {
        playerCard.Hp += hp;
    }
}