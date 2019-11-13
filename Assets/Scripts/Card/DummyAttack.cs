using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAttack : Card
{
    public Objects TargetObj;
    public override void Start()
    {
        base.Start();
        currentDmg += Player.instance.AD;
        ChangeColor();
    }
    void UpdateDamage()
    {
        if (Player.instance.AD > 0 || Player.instance.AD < 0)
        {
            ChangeColor();
            if (currentDmg == BaseSkin.cardDamage)
                currentDmg += Player.instance.AD;
        }
    }
    new private void Update()
    {
        UpdateDamage();
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
