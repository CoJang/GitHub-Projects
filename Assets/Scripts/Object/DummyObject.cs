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
    }

    protected override void OnDamageObject(int Hitdamage)
    {
        base.OnDamageObject(Hitdamage);
    }

    public override void PlayAttackAnim()
    {
        GetComponent<Animator>().SetTrigger("PlayAttackAnim");
    }

    public override void EnemyAI()
    {
        if (PhaseManager.instance.Phase == PhaseManager.PHASE.EnemyPhase)
        {
            Target = GameObject.FindGameObjectWithTag("Player");
            Target.GetComponent<Player>().DealDamage(currentDmg);
        }
    }

    public override bool EndofAnim()
    {
        IsAnimEnd = true;
        PhaseManager.instance.count++;
        PhaseManager.instance.NextEnemyAttack(PhaseManager.instance.count);
        if (PhaseManager.instance.count == PhaseManager.instance.Enemys.Length)
            PhaseManager.instance.EnemyTurnEnd();
        return IsAnimEnd;
    }

}
