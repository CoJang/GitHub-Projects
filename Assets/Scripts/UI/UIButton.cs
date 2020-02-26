using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;



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
