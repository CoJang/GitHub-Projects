using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAttack : Card
{
    public Objects TargetObj;
    public override void Start()
    {
        base.Start();
    }

    public override void Play()
    {
        base.Play();

        TargetObj = InputManager.instance.Target;
        TargetObj.DealDamage(currentDmg);

        OnPlayCard();
    }

    protected override void OnPlayCard()
    {
        base.OnPlayCard();

        Debug.Log(BaseSkin.cardName + " Played");
        area = Area.Discard;
        Hand.instance.CardDraw();
    }
}
