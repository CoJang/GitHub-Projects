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
        for(int i=0; i < 10; i++)
        {
            DeckList.Add("AttackCard");
        }
        DeckList.Insert(1, "SpellCard");
        DeckList.Insert(7, "SpellCard");
        DeckList.Insert(9, "SpellCard");
    }

    //public GameObject DrawRequest()
    public string DrawRequest()
    {
        return curDeck[0];
    }
    public string DrawRequest(int cardindex)
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
                    curDeck.Add(Grave.instance.graveDeck[i].GetComponent<Card>().BaseSkin.cardEngName);
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
                    string t = curDeck[s];
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
                    string t = curDeck[s];
                    curDeck[s] = curDeck[i - 1];
                    curDeck[i - 1] = t;
                }
                break;
        }
    }
    // Do Not Clear Current Deck, Add a Card and Shuffle 
    public void DeckShuffle(string cardname)
    {
        curDeck.Add(cardname);

        for (int i = curDeck.Count; i > 1; i--)
        {
            int s = Random.Range(0, i);
            string t = curDeck[s];
            curDeck[s] = curDeck[i - 1];
            curDeck[i - 1] = t;
        }
    }
}
