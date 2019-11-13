using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Objects
{
    static public Player instance;
    public int AP = 0;
    public int AD = 0;

    //private int APD = 0;
    //private int ADD = 0;

    private void Awake()
    {
        instance = this;
    }
    protected override void Start()
    {
        base.Start();
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
