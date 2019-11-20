using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnBT : UIButton
{
    /// <summary>
    /// [0] = Have Cost MyTurn [1] = No Cost MyTurn [2] = Enemy Turn
    /// </summary>
    public Sprite[] sprites = new Sprite[3];
    new protected void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        PhaseManager.instance.EndTurnButtonClicked();
    }



}
