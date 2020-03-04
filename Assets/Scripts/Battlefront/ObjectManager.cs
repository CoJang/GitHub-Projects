using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    static public ObjectManager instance;
    int count = 0;
    //public List<GameObject> Enemys = new List<GameObject>();
    //public List<GameObject> Alliance = new List<GameObject>();

    public List<Objects> Enemys = new List<Objects>();
    public List<Objects> Alliance = new List<Objects>();

    private void Awake()
    {
        instance = this;
    }

    public void StartEnemyTurn()
    {
        count = 0;
        Enemys[count].StartTurn();

        OnEnemyTurn();
    }
    public void OnEnemyTurn()
    {
        PhaseManager.instance.Phase = PhaseManager.PHASE.EnemyPhase;
    }

    public void EndEnemyTurn()
    {
        for (int i = 0; i < Enemys.Count; i++)
        {
            //Enemys[i].GetComponent<Objects>().EndTurn();
            //if(Enemys[i].IsAnimEnd == true)
            //{
                Enemys[i].EndTurn();
            //}
        }
        
    }

    public void NextEnemyAnim()
    {
        ++count;

        if (count <= Enemys.Count - 1)
        {
            Enemys[count].StartTurn();
        }
        else
        {
            PhaseManager.instance.Phase = PhaseManager.PHASE.EndEnemyPhase;
            PhaseManager.instance.EnemyTurnEnd();
        }
    }

    public void StartAllianceTurn()
    {
        for (int i = 0; i < Alliance.Count; i++)
        {
            //Alliance[i].GetComponent<Objects>().StartTurn();
            Alliance[i].StartTurn();
        }
    }

    public void EndAllianceTurn()
    {
        for (int i = 0; i < Alliance.Count; i++)
        {
            //Alliance[i].GetComponent<Objects>().EndTurn();
            Alliance[i].EndTurn();
        }
    }

}
