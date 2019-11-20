using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    static public PhaseManager instance;
    public GameObject endTurnBT;
    public enum PHASE
    {
        DrawPhase,
        MyPhase,
        EnemyPhase
    }

    public PHASE Phase = PHASE.DrawPhase;

    private void Awake()
    {
        instance = this;
        endTurnBT = GameObject.FindGameObjectWithTag("TurnButton");
    }

    void Update()
    {
        if(Phase == PHASE.DrawPhase)
        {
            Hand.instance.CardDraw();
            Player.instance.HealAP();
            Phase = PHASE.MyPhase;
            endTurnBT.GetComponent<SpriteRenderer>().sprite
                = endTurnBT.GetComponent<EndTurnBT>().sprites[0];
        }
    }

    public void EndTurnButtonClicked()
    {
        if (Phase == PHASE.MyPhase)
        {
            Phase = PHASE.EnemyPhase;
            Hand.instance.DiscardAll();

            endTurnBT.GetComponent<SpriteRenderer>().sprite
                = endTurnBT.GetComponent<EndTurnBT>().sprites[2];
        }
    }
    /// <summary>
    /// Check Player's Hand. If You Can't Play Any Card, EndButton Will Shine
    /// </summary>
    public void CanPlay()
    {
        if(Phase == PHASE.MyPhase && Hand.instance.CanPlayAnyCard())
            endTurnBT.GetComponent<SpriteRenderer>().sprite
                = endTurnBT.GetComponent<EndTurnBT>().sprites[0];
        else
            endTurnBT.GetComponent<SpriteRenderer>().sprite
                = endTurnBT.GetComponent<EndTurnBT>().sprites[1];
    }
}
