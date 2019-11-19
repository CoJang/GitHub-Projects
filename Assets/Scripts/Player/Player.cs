using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Objects
{
    static public Player instance;
    public int AP = 0;
    public int AD = 0;
    public int ActionPoint = 4;

    private int AP_heal = 4;
    private int MaxAP = 6;
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

    public bool OnAction(int Cost)
    {
        if (Cost <= ActionPoint)
        {
            ActionPoint -= Cost;
            Debug.LogError("Current Cost : " + ActionPoint.ToString());
            return true;
        }
        else return false;
    }

    public void HealAP()
    {
        ActionPoint += AP_heal;
        if (ActionPoint > MaxAP)
            ActionPoint = MaxAP;
    }
}
