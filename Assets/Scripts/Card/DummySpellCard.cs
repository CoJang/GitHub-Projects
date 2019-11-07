using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DummySpellCard : Card
{
    public GameObject[] objects;
    public Objects[] TargetObjs;
    
    public override void Start()
    {
        base.Start();
    }
    
    public override void Play()
    {
        base.Play();

        //InputManager.instance.Target.DealDamage(currentDmg);
        objects = GameObject.FindGameObjectsWithTag("EnemyObject");

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<Objects>().DealDamage(currentDmg);
            //Debug.Log("Damaging " + currentDmg + " To " + objects[i].name + "");
        }

        //Debug.Log(objects.Length);
        OnPlayCard();
    }

    protected override void OnPlayCard()
    {
        base.OnPlayCard();

        Debug.Log(BaseSkin.cardName + " Played");
        area = Area.Discard;
    }
}
