using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    static public Grave instance;
    public List<GameObject> graveDeck = new List<GameObject>();
    void Awake()
    {
        instance = this;
    }

    public void OnDiscard()
    {

    }

    public void AddToGrave(GameObject card)
    {
        graveDeck.Add(card);
        Hand.instance.MyHand.RemoveAt(card.GetComponent<Card>().alphaSort);
        DestroyImmediate(card);

        Hand.instance.SortingCardsInHand();
    }
}
