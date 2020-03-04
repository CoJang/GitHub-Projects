using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objects : BaseObject
{
    ///<summary> Sprites [0] = InnerSprite, [1] = FrameSprite </summary>
    protected SpriteRenderer[] Objectspr;
    protected SpriteMask      Objectmask;

    protected int currentHP;
    protected int currentDmg;
    protected TextMeshPro HPtext;
    protected float ShockFactor = 1;

    public int AP = 0;
    public int AD = 0;
    public int ActionPoint = 0;
    public int AP_heal = 4;

    protected virtual void Start()
    {
        currentHP = BaseSkin.BaseHP;
        currentDmg = BaseSkin.BaseDamege;

        HPtext = GetComponentInChildren<TextMeshPro>();
        HPtext.text = currentHP.ToString();

        ailment = gameObject.GetComponent<Ailment>();
    }

    protected override void OnDamageObject(float Hitdamage)
    {
        base.OnDamageObject(Hitdamage);

        PlayHitAnim();
        currentHP -= (int)(Hitdamage * ShockFactor);
        Debug.LogError("Object Damaged! HP : " + currentHP + " Damage : " + Hitdamage);

        HPtext.text = currentHP.ToString();

        if (currentHP <= 0)
            OnDieObject();
    }

    public override void StartTurn()
    {
        CheckNDAilment();
    }

    public override void EndTurn()
    {
        CheckDmgAilment();
    }

    public override void PlayHitAnim()
    {
        GetComponent<Animator>().SetTrigger("PlayHitAnim");
    }


    protected override void OnDieObject()
    {
        base.OnDieObject();

        ObjectManager.instance.Enemys.Remove(this);
        DestroyImmediate(gameObject);
    }

    public virtual void DealDamage(float deal)
    {
        OnDamageObject(deal);
    }

    protected void OnMouseEnter()
    {
        InputManager.instance.Target = this;
    }

    protected void OnMouseExit()
    {
        InputManager.instance.Target = null;
    }

    ///<summary> Checking Damaging Ailments at End of Turn
    ///</summary>
    public override void CheckDmgAilment()
    {
        for (int i = 0; i < ailment.states.Count; i++)
        {
            if (ailment.states[i].Duration > 0)
            {
                ailment.states[i].Duration -= 1;

                if(ailment.states[i].State == Ailment.StateList.Poison)
                    DealDamage(ailment.states[i].DamageOverTime * 
                                                    ailment.states[i].Stack);
                else
                    DealDamage(ailment.states[i].DamageOverTime);

                StateDurationCheck(i);
            }
            else
            {
                ailment.states.RemoveAt(i);
                Debug.Log(gameObject.name + "'s " + ailment.states[i].State.ToString() + " Removed !");
            } 
        }
    }

    ///<summary> Checking None-Damaging Ailments at Start of Turn
    ///</summary>
    public override void CheckNDAilment()
    {
        for (int i = 0; i < ailment.states.Count; i++)
        {
            if (ailment.states[i].Duration > 0)
            {
                ailment.states[i].Duration -= 1;

                switch(ailment.states[i].State)
                {
                    case Ailment.StateList.Downed:
                    case Ailment.StateList.Frozen:
                    case Ailment.StateList.Stuned:
                        // Spend one Turn to Recover
                        ActionPoint = 0;
                        break;
                    case Ailment.StateList.Maim:
                        // AP - 1
                        AP_heal = 3;
                        break;
                    case Ailment.StateList.Shocked:
                        // Twice damage on first hit
                        break;
                }

                StateDurationCheck(i);
            }
            else
            {
                ailment.states.RemoveAt(i);
                Debug.Log(gameObject.name + "'s " + ailment.states[i].State.ToString() + " Removed !");
            }
        }
    }

    public void StateDurationCheck()
    {
        for (int i = 0; i < ailment.states.Count; i++)
        {
            if (ailment.states[i].Duration <= 0)
            {
                ailment.states.RemoveAt(i);
                Debug.Log(gameObject.name + "'s " + ailment.states[i].State.ToString() + " Removed !");
            }
        }
    }

    public void StateDurationCheck(int index)
    {
        if (ailment.states[index].Duration <= 0)
        {
            ailment.states.RemoveAt(index);
            Debug.Log(gameObject.name + "'s " + ailment.states[index].State.ToString() + " Removed !");
        }
    }

}
