using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]

public class BaseCard : MonoBehaviour
{
    public BaseCardData BaseSkin;
    protected virtual void OnSkinCard() {}
    protected virtual void OnPlayCard() {}
    public virtual void Play() {}
    //public virtual void Play(Objects target) { }

    public virtual void Awake()
    {
        OnSkinCard();
    }

    public virtual void UpdateDamage(){}
}
