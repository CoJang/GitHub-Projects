using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    static public Grave instance;
    public List<CardList.List> graveDeck = new List<CardList.List>();
    void Awake()
    {
        instance = this;
    }

    public void OnDiscard()
    {

    }

    public void AddToGrave(GameObject card)
    {
        graveDeck.Add(card.GetComponent<Card>().BaseSkin.cardEngName);
        Hand.instance.MyHand.RemoveAt(card.GetComponent<Card>().alphaSort);
        DestroyImmediate(card);

        Hand.instance.SortingCardsInHand();
    }
}
