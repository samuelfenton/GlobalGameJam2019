using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState_Paused : EnemyState
{
    private GameManager m_gameManager = null;

    protected override void Start()
    {
        base.Start();
        m_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public override void StartState()
    {
        m_navigationAgent.enabled = false;//Game over, no need for AI
    }

    //run each frame, perfom actions
    //Return true when completed
    public override bool UpdateState()
    {
        return false;
    }

    public override bool IsValid()
    {
        return m_gameManager.m_endGame;
    }
}
