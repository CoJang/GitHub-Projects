using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine;
using TMPro;

public class Card : BaseCard
{
    private TextMeshPro[] Cardtxt;
    private SpriteRenderer[] Cardspr;

    public Quaternion alphaRot;
    public Vector3 alphaPos;

    public int alphaSort;
    public SortingGroup sorting;

    private float CardScaleFactor = 1.5f;
    private float CardUpPosFactor = 3.7f;

    protected int currentDmg;
    protected string curDmgColor;
    public int currentCost;
    protected string curCostColor;

    public enum Area
    {
        Deck,
        Hand,
        Field,
        Discard
    }

    public Area area = Area.Deck;

    protected override void OnSkinCard()
    {
        base.OnSkinCard();

        currentDmg = BaseSkin.cardDamage;
        currentCost = BaseSkin.cardCost;
        curCostColor = "<color=#FFFFFF>";
        curDmgColor = "<color=#323232>";
        // Sprites [0] = InnerSprite, [1] = FrameSprite [2] = Cost Gemstone Sprite
        Cardspr = GetComponentsInChildren<SpriteRenderer>();

        Cardspr[0].sprite = BaseSkin.cardSprite;
        Cardspr[1].sprite = BaseSkin.cardFrameSprite;
        Cardspr[2].sprite = BaseSkin.cardGemSprite;

        // [0] = Cost, [1] = Name, [2] = Text
        Cardtxt = GetComponentsInChildren<TextMeshPro>();

        Cardtxt[0].text = curCostColor + BaseSkin.cardCost.ToString();
        Cardtxt[1].text = BaseSkin.cardName;
        if (currentDmg != 0)
            Cardtxt[2].text = BaseSkin.cardpreText + curDmgColor + BaseSkin.cardDamage + BaseSkin.cardText;
        else
            Cardtxt[2].text = BaseSkin.cardpreText + BaseSkin.cardText;
    }

    public virtual void Start()
    {
        // Save Origin State
        alphaRot = transform.rotation;
        alphaPos = transform.position;
        sorting = GetComponent<SortingGroup>();
    }

    protected virtual void OnMouseEnter()
    {
        // When Mouse Over on Card, Stand Up & Bit Zoom + little Moves Up
        transform.localScale = new Vector3(CardScaleFactor, CardScaleFactor, 1);
        transform.position = new Vector3(alphaPos.x, alphaPos.y + CardUpPosFactor, alphaPos.z);
        transform.rotation = new Quaternion(0, 0, 0, 1);
        sorting.sortingOrder = 99;
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
        sorting.sortingOrder = alphaSort;

        if (InputManager.instance.GetMouseState() == false)
        {          
            InputManager.instance.MyCard = null;
        }
    }

    protected override void OnPlayCard()
    {
        base.OnPlayCard();
        Discard();
    }

    protected virtual void Discard()
    {
        area = Area.Discard;
        Grave.instance.AddToGrave(gameObject);
    }

    public enum TextType
    {
        Cost,
        Damage
    }
    public void ChangeColor(TextType type)
    {
        switch(type)
        {
            case TextType.Cost:
                if (currentCost < BaseSkin.cardCost)
                {
                    curCostColor = "<color=green>";
                    Cardtxt[0].text = curCostColor + currentCost.ToString();
                }
                else if (currentCost > BaseSkin.cardCost)
                {
                    curCostColor = "<color=red>";
                    Cardtxt[0].text = curCostColor + currentCost.ToString();
                }
                break;
            case TextType.Damage:
                if (currentDmg < BaseSkin.cardDamage)
                {
                    curDmgColor = "<color=red>";
                    Cardtxt[2].text = BaseSkin.cardpreText + curDmgColor + currentDmg + BaseSkin.cardText;
                }
                else if (currentDmg > BaseSkin.cardDamage)
                {
                    curDmgColor = "<color=green>";
                    Cardtxt[2].text = BaseSkin.cardpreText + curDmgColor + currentDmg + BaseSkin.cardText;
                }
                break;
        }
    }
    public void ChangeColor()
    {
        if (currentCost < BaseSkin.cardCost)
        {
            curCostColor = "<color=green>";
            Cardtxt[0].text = curCostColor + currentCost.ToString();
        }
        else if (currentCost > BaseSkin.cardCost)
        {
            curCostColor = "<color=red>";
            Cardtxt[0].text = curCostColor + currentCost.ToString();
        }
        else curCostColor = "<color=#FFFFFF>";

        if (currentDmg < BaseSkin.cardDamage)
        {
            curDmgColor = "<color=red>";
            Cardtxt[2].text = BaseSkin.cardpreText + curDmgColor + currentDmg + BaseSkin.cardText;
        }
        else if (currentDmg > BaseSkin.cardDamage)
        {
            //curDmgColor = "<color=green>";
            curDmgColor = "<color=blue>";
            Cardtxt[2].text = BaseSkin.cardpreText + curDmgColor + currentDmg + BaseSkin.cardText;
        }
        else curDmgColor = "<color=#323232>";

    }

    public bool BeforePlayCard()
    {
        if(Player.instance.OnAction(currentCost))
        {
            return true;
        }

        return false;
    }
}
