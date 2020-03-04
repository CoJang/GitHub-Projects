using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode()]
public class BaseObject : MonoBehaviour
{
    public Ailment ailment;
    public BaseObjectData BaseSkin;
    public bool IsAnimEnd = false;
    protected virtual void OnSkinObject() { }
    protected virtual void OnDamageObject(float Hitdamage) { }

    protected virtual void OnDieObject() { }

    public virtual void EnemyAI() { }
    public virtual void PlayAttackAnim() { }
    public virtual void PlayHitAnim() { }
    public virtual bool EndofAnim() { return IsAnimEnd; }

    public virtual void StartTurn() { }
    public virtual void EndTurn() { }

    public virtual void CheckDmgAilment() { }
    public virtual void CheckNDAilment() { }

    void Start()
    {
        OnSkinObject();
    }

}
