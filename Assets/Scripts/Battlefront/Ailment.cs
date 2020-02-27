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

    public class AilmentState
    {
        public AilmentState(StateList state, float dot, short duration, short stack)
        {
            State = state;
            DamageOverTime = dot;
            Duration = duration;
            Stack = stack;
        }

        public AilmentState(StateList state, short duration)
        {
            State = state;
            Duration = duration;
        }

        public StateList State;
        public float DamageOverTime;
        public short Duration;
        public short Stack;
    }
    public List<AilmentState> states = new List<AilmentState>();

    void Start()
    {
        

        
    }

}
