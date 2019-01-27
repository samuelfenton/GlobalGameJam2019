using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState_Chasing : EnemyState
{
    private Player m_targetPlayer = null;

    public float m_chasingSpeed = 10.0f;

    protected override void Start()
    {
        base.Start();
        m_targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    //run at swap to this state
    public override void StartState()
    {
        m_navigationAgent.enabled = true;
        m_navigationAgent.destination = m_targetPlayer.transform.position;

        m_navigationAgent.speed = m_chasingSpeed;
        m_navigationAgent.acceleration = 20;

        m_parentEnemy.m_animator.SetFloat("Speed", 1.0f);
    }

    //run each frame, perfom actions
    //Return true when completed
    public override bool UpdateState()
    {
        m_navigationAgent.destination = m_targetPlayer.transform.position;

        float distanceToTarget = Vector3.Distance(m_targetPlayer.transform.position, this.transform.position);
        return !IsValid() || distanceToTarget <= m_parentEnemy.m_atackPlayerDistance;
    }

    //run at end of state
    public override void EndState()
    {

    }

    //Is this state valid, e.g. mouse down
    //Return true when valid
    public override bool IsValid()
    {
        return CanSeePlayer() && m_parentEnemy.m_viewDistance > Vector3.Distance(m_targetPlayer.transform.position, this.transform.position);
    }

    private bool CanSeePlayer()
    {
        Vector3 distance = m_targetPlayer.transform.position - transform.position;

        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up, distance, out hit))
        {
            return (hit.collider.tag == "Player");
        }

        return false;
    }
}
