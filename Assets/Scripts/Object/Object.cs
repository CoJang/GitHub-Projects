using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : BaseObject
{
    protected SpriteRenderer[] Objectspr;
    protected SpriteMask      Objectmask;

    protected int currentHP;
    protected int currentDmg;

    protected override void OnSkinObject()
    {
        base.OnSkinObject();

        // Sprites [0] = InnerSprite, [1] = FrameSprite
        Objectspr = GetComponentsInChildren<SpriteRenderer>();

        Objectspr[0].sprite = BaseSkin.objectFrameSprite;
        //Objectspr[1].sprite = BaseSkin.objectSprite;
        // Set Visible Inside Mask
        Objectspr[1].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;


        Objectmask = GetComponentInChildren<SpriteMask>();
        Objectmask.sprite = BaseSkin.objectMask;
    }

    protected override void OnDamageObject(int Hitdamage)
    {
        base.OnDamageObject(Hitdamage);

        currentHP -= Hitdamage;
        Debug.Log("Object Damaged! HP : " + currentHP + " Damage : " + Hitdamage);
    }

    protected override void OnDieObject()
    {
        base.OnDieObject();

    }

    public virtual void DealDamage(int deal)
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

    protected virtual void Start()
    {
        currentHP = BaseSkin.BaseHP;
        currentDmg = BaseSkin.BaseDamege;
    }

}
