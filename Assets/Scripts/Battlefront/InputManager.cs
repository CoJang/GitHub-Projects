using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static public InputManager instance;
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

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
                Pointer.pointer.Init();
                Pointer.pointer.points[0] = MyCard.transform.position;
            }

        }
        //else IsClicked = false;

        if (Input.GetMouseButtonUp(0))
        {
            if (IsClicked && tempMousePos.y > 0.31f
                     && MyCard.BaseSkin.playType == BaseCardData.PlayType.AOE)
            {
                MyCard.Play();
                MyCard = null;
            }

            if (IsClicked && tempMousePos.y > 0.31f && Target != null
                    && MyCard.BaseSkin.playType == BaseCardData.PlayType.Targeting)
            {
                MyCard.Play();
                MyCard = null;
            }

            IsClicked = false;
        }              

    }
    public bool GetMouseState()
    {
        return IsClicked;
    }
}
