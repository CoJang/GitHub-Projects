using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Grave : MonoBehaviour
{
    static public Grave instance;
    public List<CardList.List> graveDeck = new List<CardList.List>();

    public TextMeshPro count;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (count == null)
            count = gameObject.GetComponentInChildren<TextMeshPro>();

        count.text = graveDeck.Count.ToString();
    }

    public void AddToGrave(GameObject card)
    {
        graveDeck.Add(card.GetComponent<Card>().BaseSkin.cardEngName);
        Hand.instance.MyHand.RemoveAt(card.GetComponent<Card>().alphaSort);
        count.text = graveDeck.Count.ToString();
        DestroyImmediate(card);

        Hand.instance.SortingCardsInHand();
    }
}
