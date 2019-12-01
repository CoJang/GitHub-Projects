using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Grave":
                Debug.Log(gameObject.name + "Clicked");
                Grave.instance.ShowGraveList();
                break;
            case "Deck":
                Debug.Log(gameObject.name + "Clicked");
                Deck.instance.ShowCurrentDeck();
                break;
            case "EndTurnButton":
                Debug.Log(gameObject.name + "Clicked");
                PhaseManager.instance.EndTurnButtonClicked();
                break;
            default:
                break;
        }
    }
}
