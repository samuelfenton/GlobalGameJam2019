using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Paused : PlayerState
{
    private GameManager m_gameManager = null;
    private Rigidbody m_rigidbody = null;

    protected override void Start()
    {
        base.Start();
        m_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public override void StartState()
    {
        m_rigidbody.velocity = Vector3.zero;
    }

    //run each frame, perfom actions
    //Return true when completed
    public override bool UpdateState()
    {
        return false;
    }

    public override bool IsValid()
    {
        return m_gameManager.m_endGame || !m_parentPlayer.m_conscious;
    }
}
