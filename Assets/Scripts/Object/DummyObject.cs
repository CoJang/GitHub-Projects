using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyObject : Objects
{
    
    protected override void Start()
    {
        base.Start();

        //Debug.Log("Game Start. Your HP : " + currentHP);
    }

    protected override void OnDamageObject(int Hitdamage)
    {
        base.OnDamageObject(Hitdamage);
    }

}
