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

        Hand.instance.CardDraw();

        Debug.Log(BaseSkin.cardName + " Played");
        OnPlayCard();
    }


}
