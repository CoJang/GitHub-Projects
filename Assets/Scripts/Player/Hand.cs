using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class Hand : MonoBehaviour
{
    static public Hand instance;
    public List<GameObject> MyHand;
    private CardList.List cardName;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Deck.instance.DeckShuffle(Deck.ShuffleCase.ClearShuffle);

        CardDraw();
        CardDraw();
        CardDraw();
    }

    public void CardDraw()
    {
        if (Deck.instance.curDeck.Count < 1)
            Deck.instance.DeckShuffle(Deck.ShuffleCase.GraveToDeck);

        cardName = Deck.instance.DrawRequest();
        Deck.instance.ClearFromDeck();

        AfterDraw();
    }

    Vector3 MidCardPos = new Vector3(0, -9.78f, 0);
    Quaternion MidCardRot = new Quaternion(0, 0, 0, 1);

    Vector3 LeftCenter = new Vector3(-1.27f, -9.78f, 0);
    Vector3 RightCenter = new Vector3(1.7f, -9.78f, 0);
    Quaternion LeftCenterRot = new Quaternion(0, 0, 0, 1);
    Quaternion RightCenterRot = new Quaternion(0, 0, 0, 1);

    public void AfterDraw()
    {
        MyHand.Add(Instantiate(CardList.instance.ReturnObj(cardName)));

        SortingCardsInHand();
    }

    public void SortingCardsInHand()
    {
        if (MyHand.Count == 0)
        { }
        else if (MyHand.Count == 1)
        {
            SetPosition(0, CardPosition.Center);
        }
        else if (MyHand.Count == 2)
        {
            SetPosition(0, CardPosition.Left);
            SetPosition(1, CardPosition.Right);
        }
        else if (MyHand.Count == 3)
        {
            SetPosition(0, new Vector3(MidCardPos.x - 2.8f, MidCardPos.y, MidCardPos.z));
            SetRotation(0, new Quaternion(MidCardRot.x, MidCardRot.y, MidCardRot.z, 1));
            SetPosition(1, CardPosition.Center);
            SetPosition(2, new Vector3(MidCardPos.x + 2.8f, MidCardPos.y, MidCardPos.z));
            SetRotation(2, new Quaternion(MidCardRot.x, MidCardRot.y, MidCardRot.z, 1));
        }
        else if (MyHand.Count == 4)
        {
            SetPosition(0, new Vector3(LeftCenter.x - 2.8f, LeftCenter.y, LeftCenter.z));
            SetRotation(0, new Quaternion(LeftCenterRot.x, LeftCenterRot.y, LeftCenterRot.z, 1));
            SetPosition(1, CardPosition.Left);
            SetPosition(2, CardPosition.Right);
            SetPosition(3, new Vector3(RightCenter.x + 2.8f, RightCenter.y, RightCenter.z));
            SetRotation(3, new Quaternion(RightCenterRot.x, RightCenterRot.y, RightCenterRot.z, 1));
        }
        // if MyHand Upper 4, And Odd Number  
        else if (MyHand.Count > 4 && (MyHand.Count % 2) == 1)
        {
            for (int i = 0; i < MyHand.Count / 2; i++)
            {
                SetPosition(i, new Vector3(MidCardPos.x - 2.8f *(MyHand.Count / 2 - i), MidCardPos.y, MidCardPos.z));
                SetRotation(i, new Quaternion(MidCardRot.x, MidCardRot.y, MidCardRot.z, 1));
            }

            SetPosition(MyHand.Count / 2, CardPosition.Center);
            int j = 1;
            for (int i = MyHand.Count / 2 + 1; i < MyHand.Count; i++, j++)
            {
                SetPosition(i, new Vector3(MidCardPos.x + 2.8f * j, MidCardPos.y, MidCardPos.z));
                SetRotation(i, new Quaternion(MidCardRot.x, MidCardRot.y, MidCardRot.z, 1));
            }
        }

        // if MyHand Upper 4, And Even Number 
        else if (MyHand.Count > 4 && (MyHand.Count % 2) == 0)
        {
            SetPosition(MyHand.Count / 2 - 1, CardPosition.Left);

            for (int i = 0; i < MyHand.Count / 2 - 1; i++)
            {
                SetPosition(i, new Vector3(LeftCenter.x - 2.8f * (MyHand.Count - (MyHand.Count / 2 + 1 + i)), LeftCenter.y, LeftCenter.z));
                SetRotation(i, new Quaternion(LeftCenterRot.x, LeftCenterRot.y, LeftCenterRot.z, 1));
            }

            SetPosition(MyHand.Count / 2, CardPosition.Right);

            int j = 1;
            for (int i = MyHand.Count / 2 + 1; i < MyHand.Count; i++, j++)
            {
                SetPosition(i, new Vector3(RightCenter.x + 2.8f * j, RightCenter.y, RightCenter.z));
                SetRotation(i, new Quaternion(RightCenterRot.x, RightCenterRot.y, RightCenterRot.z, 1));
            }
        }
        else Debug.LogError(MyHand.Count);

        PhaseManager.instance.CanPlay();
    }
    public enum CardPosition
    {
        Left,
        Center,
        Right
    }
    private void SetPosition(int cardindex, CardPosition position)
    {
        if(position == CardPosition.Center)
        {
            MyHand[cardindex].transform.position = MidCardPos;
            MyHand[cardindex].transform.rotation = MidCardRot;
            MyHand[cardindex].GetComponent<Card>().alphaPos = MidCardPos;
            MyHand[cardindex].GetComponent<Card>().alphaRot = MidCardRot;
            MyHand[cardindex].GetComponent<SortingGroup>().sortingOrder = cardindex;
            MyHand[cardindex].GetComponent<Card>().alphaSort = cardindex;
        }

        else if (position == CardPosition.Left)
        {
            MyHand[cardindex].transform.position = LeftCenter;
            MyHand[cardindex].transform.rotation = LeftCenterRot;
            MyHand[cardindex].GetComponent<Card>().alphaPos = LeftCenter;
            MyHand[cardindex].GetComponent<Card>().alphaRot = LeftCenterRot;
            MyHand[cardindex].GetComponent<SortingGroup>().sortingOrder = cardindex;
            MyHand[cardindex].GetComponent<Card>().alphaSort = cardindex;
        }

        else  //if(position == CardPosition.Right)
        {
            MyHand[cardindex].transform.position = RightCenter;
            MyHand[cardindex].transform.rotation = RightCenterRot;
            MyHand[cardindex].GetComponent<Card>().alphaPos = RightCenter;
            MyHand[cardindex].GetComponent<Card>().alphaRot = RightCenterRot;
            MyHand[cardindex].GetComponent<SortingGroup>().sortingOrder = cardindex;
            MyHand[cardindex].GetComponent<Card>().alphaSort = cardindex;
        }
    }

    private void SetPosition(int cardindex, Vector3 pos)
    {
        MyHand[cardindex].transform.position = pos;
        MyHand[cardindex].GetComponent<Card>().alphaPos = pos;
        MyHand[cardindex].GetComponent<SortingGroup>().sortingOrder = cardindex;
        MyHand[cardindex].GetComponent<Card>().alphaSort = cardindex;
    }

    private void SetRotation(int cardindex, Quaternion rot)
    {
        MyHand[cardindex].transform.rotation = rot;
        MyHand[cardindex].GetComponent<Card>().alphaRot = rot;
    }

    public void Discard(int cardindex)
    { 
        DestroyImmediate(MyHand[cardindex]);
        SortingCardsInHand();
    }

    //public void DiscardAll()
    //{
    //    for (int i = 0; i < MyHand.Count; i++)
    //    {
            
    //    }
    //}

    public bool CanPlayAnyCard()
    {
        for(int i = 0; i < MyHand.Count; i++)
        {
            if (MyHand[i].GetComponent<Card>().currentCost <= Player.instance.ActionPoint)
                return true;
        }
        return false;
    }
}
