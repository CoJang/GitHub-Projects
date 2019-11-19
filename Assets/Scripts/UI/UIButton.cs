using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public bool IsClicked = false;
    protected void OnMouseEnter()
    {
        InputManager.instance.UI = this;
    }

    protected void OnMouseUpAsButton()
    {
        IsClicked = true;
    }

    protected void OnMouseExit()
    {
        InputManager.instance.UI = null;
        IsClicked = false;
    }
}
