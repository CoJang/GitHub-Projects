using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Card : BaseCard
{
    private TextMeshPro[] Cardtxt;
    private SpriteRenderer[] Cardspr;

    private Quaternion alphaRot;
    public Vector3 alphaPos;

    private float CardScaleFactor = 1.5f;
    private float CardUpPosFactor = 3.7f;

    protected int currentDmg;

    protected enum Area
    {
        Deck,
        Hand,
        Field,
        Discard
    }

    protected Area area = Area.Hand;

    protected override void OnSkinCard()
    {
        base.OnSkinCard();

        // Sprites [0] = InnerSprite, [1] = FrameSprite [2] = Cost Gemstone Sprite
        Cardspr = GetComponentsInChildren<SpriteRenderer>();

        Cardspr[0].sprite = BaseSkin.cardSprite;
        Cardspr[1].sprite = BaseSkin.cardFrameSprite;
        Cardspr[2].sprite = BaseSkin.cardGemSprite;

        // [0] = Cost, [1] = Name, [2] = Text
        Cardtxt = GetComponentsInChildren<TextMeshPro>();

        Cardtxt[0].text = BaseSkin.cardCost.ToString();
        Cardtxt[1].text = BaseSkin.cardName;
        Cardtxt[2].text = BaseSkin.cardText;

        currentDmg = BaseSkin.cardDamage;
    }

    public virtual void Start()
    {
        // Save Origin State
        alphaRot = transform.rotation;
        alphaPos = transform.position;
    }

    protected virtual void OnMouseEnter()
    {
        // When Mouse Over on Card, Stand Up & Bit Zoom + little Moves Up
        transform.localScale = new Vector3(CardScaleFactor, CardScaleFactor, 1);
        transform.position = new Vector3(alphaPos.x, alphaPos.y + CardUpPosFactor, alphaPos.z);
        transform.rotation = new Quaternion(0, 0, 0, 1);
        InputManager.instance.MyCard = this;
    }


    protected virtual void OnMouseUp()
    {
        //Back To Origin Position In Hand
        transform.position = alphaPos;
    }
    protected virtual void OnMouseExit()
    {
        // To Origin State
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = alphaPos;
        transform.rotation = alphaRot;

        if(InputManager.instance.GetMouseState() == false)
            InputManager.instance.MyCard = null;
    }
    
}
