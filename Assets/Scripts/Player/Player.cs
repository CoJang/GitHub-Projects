using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Objects
{
    static public Player instance;
    public int DrawPoint = 4;

    /// <summary> [0] = feeled spr, [1] = empty spr </summary>
    [SerializeField] Sprite[] spr = new Sprite[2];

    private int MaxAP = 6;
    //private int APD = 0;
    //private int ADD = 0;
    SpriteRenderer[] APspr;

    private void Awake()
    {
        instance = this;
    }
    protected override void Start()
    {
        base.Start();
        APspr = GameObject.Find("ActionPoints").GetComponentsInChildren<SpriteRenderer>();

        for(int i = 0; i < 6; i++)
        {
            APspr[i].sprite = spr[1];
        }

        //ObjectManager.instance.Alliance.Add(gameObject);
        ObjectManager.instance.Alliance.Add(this);
    }

    protected override void OnDieObject()
    {
        base.OnDieObject();
        Debug.LogError("Game Over!");
        PhaseManager.instance.Phase = PhaseManager.PHASE.EnemyPhase;
    }

    public bool OnAction(int Cost)
    {
        if (Cost <= ActionPoint)
        {
            ActionPoint -= Cost;
            UpdateAPspr();
            return true;
        }
        else return false;
    }

    public void HealAP()
    {
        ActionPoint += AP_heal;
        if (ActionPoint > MaxAP)
            ActionPoint = MaxAP;

        UpdateAPspr();
    }

    public void UpdateAPspr()
    {
        for(int i = 0; i < ActionPoint; i++)
        {
            APspr[i].sprite = spr[0];
        }

        for(int i = 0; i < MaxAP - ActionPoint; i++)
        {
            APspr[MaxAP - i - 1].sprite = spr[1];
        }
    }

    public override void StartTurn()
    {
        //base.StartTurn();
        CheckNDAilment();
        Hand.instance.OnNewRound();
        HealAP();

        PhaseManager.instance.Phase = PhaseManager.PHASE.PlayerPhase;
        UIButton.instance.ChangeEndButton(true);
    }

    public override void EndTurn()
    {
        //base.EndTurn();
        Hand.instance.DiscardAll();
        CheckDmgAilment();

    }
}
