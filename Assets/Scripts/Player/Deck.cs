using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deck : MonoBehaviour
{
    static public Deck instance;
    public List<CardList.List> DeckList = new List<CardList.List>();
    public List<CardList.List> curDeck = new List<CardList.List>();

    public TextMeshPro count;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (count == null)
            count = gameObject.GetComponentInChildren<TextMeshPro>();

        for (int i=0; i < 6; i++)
        {
            DeckList.Add(CardList.List.AttackCard);
        }
        DeckList.Add(CardList.List.SpellCard);
        DeckList.Add(CardList.List.SpellCard);
        DeckList.Add(CardList.List.SpellCard);
        DeckList.Add(CardList.List.Focus);
        DeckList.Add(CardList.List.Focus);
    }

    public CardList.List DrawRequest()
    {
        count.text = curDeck.Count.ToString();
        return curDeck[0];
    }
    public CardList.List DrawRequest(int cardindex)
    {
        count.text = curDeck.Count.ToString();
        return curDeck[cardindex];
    }
    public void ClearFromDeck()
    {
        curDeck.RemoveAt(0);
        count.text = curDeck.Count.ToString();
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

    /// <summary> 
    /// Clear Current Deck And Shuffle
    /// GraveToDeck = Shuffle From Grave[source]
    /// ClearShuffle = Shuffle From Origin DeckList
    /// </summary>
    public void DeckShuffle(ShuffleCase shuffle)
    {
        switch(shuffle)
        {
            case ShuffleCase.ClearShuffle:
                curDeck.Clear();
                CopyDeck(ShuffleCase.ClearShuffle);
                Randomize(Grave.instance.graveDeck.Count);
                break;
            case ShuffleCase.GraveToDeck:
                curDeck.Clear();
                CopyDeck(ShuffleCase.GraveToDeck);
                Randomize(Grave.instance.graveDeck.Count);
                Grave.instance.graveDeck.Clear();
                break;
        }
    }

    /// <summary> Do Not Clear Current Deck, Add a Card and Shuffle </summary>
    public void DeckShuffle(CardList.List cardname)
    {
        curDeck.Add(cardname);
        Randomize(curDeck.Count);
        count.text = curDeck.Count.ToString();
    }

    public void Randomize(int count)
    {
        for (int i = count; i > 1; i--)
        {
            int s = Random.Range(0, i);
            CardList.List t = curDeck[s];
            curDeck[s] = curDeck[i - 1];
            curDeck[i - 1] = t;
        }
    }

    public void Randomize(List<CardList.List> list)
    {
        for (int i = list.Count; i > 1; i--)
        {
            int s = Random.Range(0, i);
            CardList.List t = list[s];
            list[s] = list[i - 1];
            list[i - 1] = t;
        }
    }

    /// <summary> Show Remains of Current Deck Randomly </summary>
    public void ShowCurrentDeck()
    {
        List<CardList.List> tempList = new List<CardList.List>();

        for(int i = 0; i < curDeck.Count; i++)
        {
            tempList.Add(curDeck[i]);
        }

        Randomize(tempList);

        for(int i = 0; i < tempList.Count; i++)
        {
            Debug.Log(tempList[i].ToString());
        }
    }
}
