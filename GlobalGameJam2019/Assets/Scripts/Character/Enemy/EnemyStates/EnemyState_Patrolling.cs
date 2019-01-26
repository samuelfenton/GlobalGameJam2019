using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState_Patrolling : EnemyState
{
    private int m_currentIndex = 0;

    private float m_arrivalDistance = 0.1f;

    public float m_patrolSpeed = 5.0f;

    protected override void Start()
    {
        base.Start();
        m_navigationAgent.destination = m_parentEnemy.m_patrolNodes[m_currentIndex].transform.position;
    }

    //run at swap to this state
    public override void StartState()
    {
        m_navigationAgent.enabled = true;
        m_navigationAgent.destination = m_parentEnemy.m_patrolNodes[m_currentIndex].transform.position;

        m_navigationAgent.speed = m_patrolSpeed;
        m_navigationAgent.acceleration = 20;

        m_parentEnemy.m_animator.SetFloat("Speed", 0.0f); 

    }

    //run each frame, perfom actions
    //Return true when completed
    public override bool UpdateState()
    {
        if (Vector3.Distance(transform.position, m_parentEnemy.m_patrolNodes[m_currentIndex].transform.position) < m_arrivalDistance) //At next point
        {
            m_currentIndex++;
            if (m_currentIndex >= m_parentEnemy.m_patrolNodes.Count)
                m_currentIndex = 0;
            m_navigationAgent.destination = m_parentEnemy.m_patrolNodes[m_currentIndex].transform.position;
           
        }
        
        return true;
    }

    //run at end of state
    public override void EndState()
    {

    }

    //Is this state valid, e.g. mouse down
    //Return true when valid
    public override bool IsValid()
    {
        return true;
    }
}
