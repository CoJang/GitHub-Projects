using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public static CardList instance;

    public enum List
    {
        None,
        AttackCard,
        SpellCard,
        Focus
    }

    //GameObject[] Cards = new GameObject[sizeof(List)];
    GameObject[] Cards;

    public GameObject ReturnObj(List name)
    {
        switch(name)
        {
            case List.AttackCard:
                return Cards[0];
            case List.Focus:
                return Cards[1];
            case List.SpellCard:
                return Cards[2];
            case List.None:
            default:
                return null;
                
        }
    }

    void Awake()
    {
        instance = this;
        Cards = Resources.LoadAll<GameObject>("Prefabs/Cards/");
        //Cards = Resources.LoadAll("Prefabs/Cards/") as GameObject;
        //var Cards = Resources.LoadAll<GameObject>("Prefabs/Cards/");
        //GameObject Cards = Instantiate(Resources.Load("Prefabs/Cards/", typeof(GameObject))) as GameObject;
    }
}
