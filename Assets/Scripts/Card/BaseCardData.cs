using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Now You Can Make Card's Base Data, In Editor with right click
[CreateAssetMenu(menuName = "Base of Card Data")]
public class BaseCardData : ScriptableObject
{
   public enum PlayType
    {
        BattleCry,
        Targeting,
        AOE,
        None
    }

    public PlayType playType = PlayType.None;

    public Sprite cardFrameSprite;
    public Sprite cardSprite;
    public Sprite cardGemSprite;

    //public SpriteState cardSpriteState;

    public int cardCost;
    public string cardName;
    public int cardDamage;

    [TextArea(15, 20)]
    public string cardText;

}
