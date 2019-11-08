using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class Hand : MonoBehaviour
{
    static public Hand instance;
    public List<GameObject> MyHand;
    private string cardName;

    Vector3 MidCardPos = new Vector3(0, -9.78f, 0);
    Quaternion MidCardRot = new Quaternion(0, 0, 0, 1);

    public GameObject[] Cards = new GameObject[2];

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //GameObject[] Objs = GameObject.FindGameObjectsWithTag("Card");
        //MyHand.AddRange(Objs);


        //for(int i = 0; i < MyHand.Count; i++)
        //{
        //    Objs[i].GetComponent<SortingGroup>().sortingOrder = i;
        //    Objs[i].GetComponent<Card>().alphaSort = i;
        //    Objs[i].GetComponent<Card>().area = Card.Area.Hand;
        //}

        //Debug.Log("Hand Size = " + MyHand.Count);
        Deck.instance.CopyDeck();
        CardDraw();
    }

    public void CardDraw()
    {
        cardName = Deck.instance.DrawRequest();
        Deck.instance.ClearFromDeck();

        AfterDraw();
    }

    public void AfterDraw()
    {
        /* 
         * add to hand
         * set a new card's pos, rot
         * instansiate(create new card)
         * set a new card's sorting group
         * 
         * */
         switch(cardName)
        {
            case "AttackCard":
                //Instantiate(Cards[0], MidCardPos, MidCardRot);
                MyHand.Add(Instantiate(Cards[0], MidCardPos, MidCardRot));
                MyHand[MyHand.Count - 1].GetComponent<SortingGroup>().sortingOrder = MyHand.Count;
                break;
            case "SpellCard":
                MyHand.Add(Instantiate(Cards[1], MidCardPos, MidCardRot));
                MyHand[MyHand.Count - 1].GetComponent<SortingGroup>().sortingOrder = MyHand.Count;
                break;
        }
    }

   // private void Update()
   // {
        //switch(MyHand.Count)
        //{
        //    case 1: 
        //        MyHand[0].transform.position = MidCardPos;
        //        MyHand[0].transform.rotation = MidCardRot;
        //        break;
        //    case 2:
        //        MyHand[0].transform.position = new Vector3(0 - (2.5f * MyHand.Count - 1), -9.78f -(0.3f * MyHand.Count -1), 0);
        //        MyHand[0].transform.rotation = new Quaternion(0, 0, -(10.0f * MyHand.Count - 1), 1);
        //        MyHand[1].transform.position = MidCardPos;
        //        MyHand[1].transform.rotation = MidCardRot;
        //        break;
        //    case 3:
        //        MyHand[0].transform.position = new Vector3(0 - (2.5f * MyHand.Count - 2), -9.78f - (0.3f * MyHand.Count - 2), 0);
        //        MyHand[0].transform.rotation = new Quaternion(0, 0, -(10.0f * MyHand.Count - 1), 1);
        //        MyHand[1].transform.position = new Vector3(0 - (2.5f * MyHand.Count - 1), -9.78f - (0.3f * MyHand.Count - 1), 0);
        //        MyHand[1].transform.rotation = new Quaternion(0, 0, -(10.0f * MyHand.Count - 1), 1);
        //        MyHand[2].transform.position = MidCardPos;
        //        MyHand[2].transform.rotation = MidCardRot;
        //        break;
        //}
    // }
}
