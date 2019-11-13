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
    public int cardDamage;
    public string cardName;
    public CardList.List cardEngName;

    [TextArea(5, 5)]
    public string cardpreText;
    [TextArea(15, 10)]
    public string cardText;

}
