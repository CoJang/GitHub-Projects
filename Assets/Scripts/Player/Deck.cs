using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    static public Deck instance;
    public List<CardList.List> DeckList = new List<CardList.List>();
    public List<CardList.List> curDeck = new List<CardList.List>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for(int i=0; i < 6; i++)
        {
            DeckList.Add(CardList.List.AttackCard);
        }
        DeckList.Add(CardList.List.SpellCard);
        DeckList.Add(CardList.List.SpellCard);
        DeckList.Add(CardList.List.SpellCard);
        DeckList.Add(CardList.List.Focus);
        DeckList.Add(CardList.List.Focus);
    }

    //public GameObject DrawRequest()
    public CardList.List DrawRequest()
    {
        return curDeck[0];
    }
    public CardList.List DrawRequest(int cardindex)
    {
        return curDeck[cardindex];
    }
    public void ClearFromDeck()
    {
        curDeck.RemoveAt(0);
    }
    public enum ShuffleCase
    {
        GraveToDeck,
        ClearShuffle
    }

    public void CopyDeck(ShuffleCase copytype)
    {
        switch(copytype)
        {
            case ShuffleCase.ClearShuffle:
                for (int i = 0; i < DeckList.Count; i++)
                {
                    curDeck.Add(DeckList[i]);
                }
                break;
            case ShuffleCase.GraveToDeck:
                for (int i = 0; i < Grave.instance.graveDeck.Count; i++)
                {
                    curDeck.Add(Grave.instance.graveDeck[i]);
                }
                break;
        }
    }

    // Clear Current Deck And Shuffle
    // GraveToDeck = Shuffle From Grave[source]
    // ClearShuffle = Shuffle From Origin DeckList
    public void DeckShuffle(ShuffleCase shuffle)
    {
        switch(shuffle)
        {
            case ShuffleCase.ClearShuffle:
                curDeck.Clear();
                CopyDeck(ShuffleCase.ClearShuffle);
                for(int i = DeckList.Count; i > 1; i--)
                {
                    int s = Random.Range(0, i);
                    CardList.List t = curDeck[s];
                    curDeck[s] = curDeck[i - 1];
                    curDeck[i - 1] = t;
                }
                break;
            case ShuffleCase.GraveToDeck:
                curDeck.Clear();
                CopyDeck(ShuffleCase.GraveToDeck);
                for (int i = Grave.instance.graveDeck.Count; i > 1; i--)
                {
                    int s = Random.Range(0, i);
                    CardList.List t = curDeck[s];
                    curDeck[s] = curDeck[i - 1];
                    curDeck[i - 1] = t;
                }
                Grave.instance.graveDeck.Clear();
                break;
        }
    }
    // Do Not Clear Current Deck, Add a Card and Shuffle 
    public void DeckShuffle(CardList.List cardname)
    {
        curDeck.Add(cardname);

        for (int i = curDeck.Count; i > 1; i--)
        {
            int s = Random.Range(0, i);
            CardList.List t = curDeck[s];
            curDeck[s] = curDeck[i - 1];
            curDeck[i - 1] = t;
        }
    }
}
