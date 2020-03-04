using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DummyObject : Objects
{
    GameObject Target;
    protected override void Start()
    {
        base.Start();
        //ObjectManager.instance.Enemys.Add(gameObject);
        ObjectManager.instance.Enemys.Add(this);
    }

    protected override void OnDamageObject(float Hitdamage)
    {
        base.OnDamageObject(Hitdamage);
    }

    public override void PlayAttackAnim()
    {
        GetComponent<Animator>().SetTrigger("PlayAttackAnim");
    }

    public override void EnemyAI()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        Target.GetComponent<Player>().DealDamage(currentDmg);
    }

    public override bool EndofAnim()
    {
        IsAnimEnd = true;
        EndTurn();
        ObjectManager.instance.NextEnemyAnim();

        return IsAnimEnd;
    }

    public override void StartTurn()
    {
        //base.StartTurn();
        CheckNDAilment();

        PlayAttackAnim();
        //EnemyAI();

    }

    public override void EndTurn()
    {
        //base.EndTurn();
        CheckDmgAilment();
    }

}
