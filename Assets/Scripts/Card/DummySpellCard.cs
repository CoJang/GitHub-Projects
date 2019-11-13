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
        currentDmg += Player.instance.AP;
        ChangeColor();
    }

    void UpdateDamage()
    {
        if (Player.instance.AP > 0 || Player.instance.AP < 0)
        {
            ChangeColor();
            if(currentDmg == BaseSkin.cardDamage)
                currentDmg += Player.instance.AP;
        }
    }

    new private void Update()
    {
        UpdateDamage();
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

        //Debug.Log(BaseSkin.cardName + " Played");
        OnPlayCard();
    }

    protected override void OnPlayCard()
    {
        base.OnPlayCard();
        Player.instance.AP++;
    }

}
