using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : Card
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Play()
    {
        base.Play();

        Hand.instance.CardDraw();
        Hand.instance.CardDraw();

        Debug.LogError(BaseSkin.cardName + " Played");
        OnPlayCard();
    }
}
