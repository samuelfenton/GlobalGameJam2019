﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Attack : PlayerState
{
    private GameManager m_gameManager = null;

    public GameObject m_thrownBottle = null;

    public AnimationClip m_attackingAnimation = null;

    private float m_totalAttackTime = 1.0f;

    [Tooltip("Time of from starting anaimtion throw, to actual throw")]
    public float m_throwAttackTime = 0.2f;

    [Tooltip("Offset from character 0,0,0 bottle is thrown from")]
    public Vector3 m_thrownOffset = new Vector3();

    [Tooltip("Offset from character 0,0,0 bottle is thrown from")]
    public float m_throwSpeed = 1.0f;

    private bool m_attacking = false;

    protected override void Start()
    {
        base.Start();
        m_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        m_totalAttackTime = m_attackingAnimation.length *0.95f;
    }
    //run at swap to this state
    public override void StartState()
    {
        m_attacking = true;
        m_gameManager.nAlcoholBottles -= 1;
        m_parentPlayer.m_animator.SetBool("Attack", true);
        StartCoroutine(ThrowBottle());
        StartCoroutine(AnimationEnded());
    }

    //run each frame, perfom actions
    //Return true when completed
    public override bool UpdateState()
    {
        return !m_attacking;
    }

    //run at end of state
    public override void EndState()
    {
        m_parentPlayer.m_animator.SetBool("Attack", false);
    }

    //Is this state valid, e.g. mouse down
    //Return true when valid
    public override bool IsValid()
    {
        return Input.GetMouseButtonDown(0) && m_gameManager.nAlcoholBottles > 0;
    }

    private IEnumerator ThrowBottle()
    {
        yield return new WaitForSeconds(m_throwAttackTime);

        float mouseRatioX = Input.mousePosition.x / Screen.width;
        float mouseRatioY = Input.mousePosition.y / Screen.height;

        Vector3 mouseVector = new Vector3(-0.5f + mouseRatioX, 0, -0.5f + mouseRatioY);

        //Make bottle
        GameObject thrownBottle = Instantiate(m_thrownBottle);

        thrownBottle.transform.position = mouseVector.normalized * m_thrownOffset.z + Vector3.up * m_thrownOffset.y;//Add offset
        thrownBottle.transform.position += transform.position; //add parent position

        thrownBottle.transform.LookAt(thrownBottle.transform.position + mouseVector, Vector3.up);

        thrownBottle.GetComponent<Rigidbody>().velocity = mouseVector.normalized * m_throwSpeed; //THROW!
    }

    private IEnumerator AnimationEnded()
    {
        yield return new WaitForSeconds(m_totalAttackTime);
        m_attacking = false;
    }
}
