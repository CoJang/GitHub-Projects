using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class BaseObject : MonoBehaviour
{
    public BaseObjectData BaseSkin;
    public bool IsAnimEnd = false;
    protected virtual void OnSkinObject() { }
    protected virtual void OnDamageObject(int Hitdamage) { }

    protected virtual void OnDieObject() { }

    public virtual void EnemyAI() { }
    public virtual void PlayAttackAnim() { }
    public virtual void PlayHitAnim() { }
    public virtual bool EndofAnim() { return IsAnimEnd; }

    void Start()
    {
        OnSkinObject();
    }

}
