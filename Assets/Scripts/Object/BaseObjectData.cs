using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Now You Can Make Object's Base Data, In Editor with right click
[CreateAssetMenu(menuName = "Base of Object Data")]
public class BaseObjectData : ScriptableObject
{

    public Sprite objectFrameSprite;
    public Sprite objectSprite;
    public Sprite objectMask;
    public Sprite objectBloodVessel;

    //public SpriteState cardSpriteState;

    public int BaseHP;

    public int BaseDamege;

}
