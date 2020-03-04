using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    static public PhaseManager instance;

    public enum PHASE
    {
        DrawPhase,
        StartPlayerPhase,
        PlayerPhase,
        EndPlayerPhase,
        StartEnemyPhase,
        EnemyPhase,
        EndEnemyPhase
    }

    public PHASE Phase = PHASE.DrawPhase;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Deck.instance.DeckShuffle();
        StartNewRound();
    }

    public void StartNewRound()
    {
        if (Phase == PHASE.DrawPhase)
        {
            Phase = PHASE.StartPlayerPhase;

            ObjectManager.instance.StartAllianceTurn();
        }
    }

    public void EndTurnButtonClicked()
    {
        if (Phase == PHASE.PlayerPhase)
        {
            Phase = PHASE.EndPlayerPhase;

            ObjectManager.instance.EndAllianceTurn();

            Phase = PHASE.StartEnemyPhase;
            ObjectManager.instance.StartEnemyTurn();
        }
    }

    public void EnemyTurnEnd()
    {
        Phase = PHASE.DrawPhase;
        StartNewRound();
    }
}
