using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : CharacterState
{
    [HideInInspector]
    public Enemy m_parentEnemy = null;
    protected NavMeshAgent m_navigationAgent;

    protected override void Start()
    {
        base.Start();
        m_parentEnemy = GetComponent<Enemy>();
        m_navigationAgent = GetComponent<NavMeshAgent>();
    }
}
