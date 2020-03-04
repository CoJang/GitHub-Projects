using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrutalAttack : Card
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

        CauseBleeding(TargetObj, (currentDmg / 3), 2, 1);

        Debug.LogError(BaseSkin.cardName + " Played");
        OnPlayCard();
    }

    public void CauseBleeding(Objects target, float dot, short duration, short stack)
    {
        
        target.ailment.states.Add(new AilmentState
            (Ailment.StateList.Bleeding, dot, duration, stack));

        //Debug.Log("Target's Ailment List : " + target.ailment.states.Count);
        target.ailment.ShowStates();
    }
}
