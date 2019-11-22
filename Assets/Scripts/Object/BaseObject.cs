using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class BaseObject : MonoBehaviour
{
    public BaseObjectData BaseSkin;
    protected virtual void OnSkinObject() { }
    protected virtual void OnDamageObject(int Hitdamage) { }

    protected virtual void OnDieObject() { }

    void Start()
    {
        OnSkinObject();
    }

}
