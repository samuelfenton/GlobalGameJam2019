using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Attack : PlayerState
{
    private GameManager m_gameManager = null;

    public float m_attackTime = 1.0f;

    private bool m_attacking = false;

    protected override void Start()
    {
        base.Start();
        m_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    //run at swap to this state
    public override void StartState()
    {
        m_attacking = true;
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

    }

    //Is this state valid, e.g. mouse down
    //Return true when valid
    public override bool IsValid()
    {
        return Input.GetMouseButtonDown(0) && m_gameManager.nAlcoholBottles > 0;
    }

    private IEnumerator AnimationEnded()
    {
        yield return new WaitForSeconds(m_attackTime);
        m_attacking = false;
    }
}
