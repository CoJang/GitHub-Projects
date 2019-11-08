using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    static public Deck instance;
    public List<string> DeckList = new List<string>();
    public List<string> curDeck = new List<string>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for(int i=0; i < 5; i++)
        {
            DeckList.Add("AttackCard");
        }
        DeckList.Insert(1, "SpellCard");
    }

    //public GameObject DrawRequest()
    public string DrawRequest()
    {
        return curDeck[0];
    }
    public void ClearFromDeck()
    {
        curDeck.RemoveAt(0);
    }

    public void CopyDeck()
    {
        //instance.curDeck.CopyTo
        for (int i = 0; i < DeckList.Count; i++)
        {
            curDeck.Add(DeckList[i]);
        }
    }
}
