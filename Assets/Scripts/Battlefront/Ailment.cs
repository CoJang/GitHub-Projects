using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ailment : MonoBehaviour
{
    public enum StateList
    {
        Bleeding,
        Poison,
        Burn,
        Suffocation,

        Downed,  // -------------------------
        Frozen,  // Spend one Turn to Recover
        Stuned,  // -------------------------
        Maim,    // AP - 1
        Shocked  // Twice damage on first hit
    }

    public List<AilmentState> states = new List<AilmentState>();

    private void PrintDetailState(int index)
    {
        Debug.Log("State Name : " + states[index].State);
        Debug.Log("Damage Over Time : " + states[index].DamageOverTime);
        Debug.Log("Duration : " + states[index].Duration);
        Debug.Log("Stack : " + states[index].Stack);
    }
    public void ShowStates()
    {
        for(int i = 0; i < states.Count; i++)
        {
            PrintDetailState(i);
        }
    }

}

public class AilmentState
{
    public AilmentState(Ailment.StateList state, float dot, short duration, short stack)
    {
        State = state;
        DamageOverTime = dot;
        Duration = duration;
        Stack = stack;
    }

    public AilmentState(Ailment.StateList state, short duration)
    {
        State = state;
        Duration = duration;
    }

    public Ailment.StateList State;
    public float DamageOverTime;
    public short Duration;
    public short Stack;
}
