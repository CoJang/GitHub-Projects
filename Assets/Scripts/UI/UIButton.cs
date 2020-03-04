using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    static public UIButton instance;
    public SpriteRenderer endTurnBT;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// [0] = Have Cost MyTurn 
    /// [1] = No Cost MyTurn
    /// [2] = Enemy Turn
    /// </summary>
    public Sprite[] spr = new Sprite[3];

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
                ChangeEndButton();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Check Player's Hand. If You Can't Play Any Card, EndButton Will Be Shine
    /// </summary>
    public void ChangeEndButton(bool trueorfalse)
    {
        if (trueorfalse == true)
        {
            endTurnBT.sprite = spr[0];
           // Debug.Log("Sprite Changed");
        }
        else
        {
            endTurnBT.sprite = spr[1];
           // Debug.Log("Sprite Changed");
        }
    }

    public void ChangeEndButton()
    {
        endTurnBT.sprite = spr[2];
    }

    public void OnNewGameButtonCilcked()
    {
        SceneManager.LoadScene("Battlefront");
    }

    public void OnLoadGameButtonCilcked()
    {
        SceneManager.LoadScene("Battlefront");
    }
    public void OnOpitionButtonCilcked()
    {
        Debug.Log("OptionButtonClicked");
    }
    public void OnQuitButtonCilcked()
    {
        Application.Quit();
    }
}
