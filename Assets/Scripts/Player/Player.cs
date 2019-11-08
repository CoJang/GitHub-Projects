using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Objects
{

    new void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected override void OnDieObject()
    {
        base.OnDieObject();
    }

    protected override void OnDamageObject(int Hitdamage)
    {
        base.OnDamageObject(Hitdamage);
    }

    public override void DealDamage(int deal)
    {
        base.DealDamage(deal);
    }
}
