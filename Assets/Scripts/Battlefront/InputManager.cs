using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static public InputManager instance;
    public UIButton UI;
    public Objects Target;
    public Card MyCard;

    private Vector3 mousePos;
    private Vector3 tempMousePos;
    private bool IsClicked = false;

    private void Awake()
    {
        instance = this; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (Input.GetKeyDown(KeyCode.Tab)) Map.instance.PopMap();

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //Deck.instance.DeckShuffle(Deck.ShuffleCase.ClearShuffle);
        //    //Deck.instance.DeckShuffle(Deck.ShuffleCase.GraveToDeck);
        //    //Deck.instance.DeckShuffle("SpellCard");
        //}

        if (PhaseManager.instance.Phase != PhaseManager.PHASE.MyPhase) return;

        tempMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        tempMousePos = Camera.main.ScreenToViewportPoint(tempMousePos);

        if (Input.GetMouseButton(0) && MyCard != null)
        {
            IsClicked = true;
            // Moves Card To Mouse Position
            mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
            MyCard.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            if (MyCard.BaseSkin.playType == BaseCardData.PlayType.Targeting && tempMousePos.y > 0.31f)
            {
                MyCard.transform.position = MyCard.alphaPos;

                // Render Targeting Arrow [Start At MousePos(CardPos)]
                Pointer.pointer.Init();
                Pointer.pointer.points[0] = MyCard.transform.position;
            }

        }
        //else IsClicked = false;

        if (Input.GetMouseButtonUp(0))
        {
            // if AOE Card Drag & Upper Screen's 31%
            if (IsClicked && tempMousePos.y > 0.31f
                     && MyCard.BaseSkin.playType == BaseCardData.PlayType.AOE)
            {
                PlayCard();
                MyCard = null;
            }

            // if Targetting Card Drag & Upper Screen's 31% & Target is Not null
            if (IsClicked && tempMousePos.y > 0.31f && Target != null
                    && MyCard.BaseSkin.playType == BaseCardData.PlayType.Targeting)
            {
                PlayCard();
                MyCard = null;
            }

            // Drag False
            IsClicked = false;
        }              

    }
    public bool GetMouseState()
    {
        return IsClicked;
    }

    public void PlayCard()
    {
        if (MyCard.BeforePlayCard())
        {
            MyCard.Play();
            //Hand.instance.UpdateCards();
        }
        else
            Debug.LogError("Not Enough Cost!");
    }
}
