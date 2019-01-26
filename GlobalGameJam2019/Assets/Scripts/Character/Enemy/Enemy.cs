using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public float m_atackPlayerDistance = 1.3f;

    [SerializeField]
    private NavMeshAgent m_navigationAgent;

    public float m_viewDistance;

    public float Rotspeed;

    public List<GameObject> m_patrolNodes = new List<GameObject>();

    // Use this for initialization
    void Awake()
    {
        m_navigationAgent = GetComponent<NavMeshAgent>();

        m_navigationAgent.angularSpeed = Rotspeed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //State Machine!
        if (m_currentState.UpdateState())//State done
        {
            foreach (CharacterState playerState in m_currentState.m_nextStates)
            {
                if (playerState.IsValid())
                {
                    SwapStates(playerState);
                    break;
                }
            }
        }
    }

    public void SoberDown()
    {
        m_conscious = false;
    }
}
