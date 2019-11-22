using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAttack : Card
{
    public Objects TargetObj;
    public override void Start()
    {
        base.Start();
        UpdateDamage();
    }
    public override void UpdateDamage()
    {
        if (Player.instance.AD > 0 || Player.instance.AD < 0)
        {
            if (currentDmg != BaseSkin.cardDamage + Player.instance.AD)
                currentDmg = BaseSkin.cardDamage + Player.instance.AD;
            ChangeColor();
        }
    }

    public override void Play()
    {
        base.Play();

        TargetObj = InputManager.instance.Target;
        TargetObj.DealDamage(currentDmg);

        Hand.instance.CardDraw();

        Debug.LogError(BaseSkin.cardName + " Played");
        OnPlayCard();
    }


}
