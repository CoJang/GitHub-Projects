using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DummyObject : Objects
{
    public TextMeshPro HPtext;
    protected override void Start()
    {
        base.Start();

        HPtext = GetComponentInChildren<TextMeshPro>();
        HPtext.text = currentHP.ToString();
        //Debug.Log("Game Start. Your HP : " + currentHP);
    }

    protected override void OnDamageObject(int Hitdamage)
    {
        base.OnDamageObject(Hitdamage);

        HPtext.text = currentHP.ToString();
    }

}
