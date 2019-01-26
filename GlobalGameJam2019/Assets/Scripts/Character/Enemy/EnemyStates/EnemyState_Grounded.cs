using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Grounded : EnemyState
{
    public float m_downedTime = 5.0f;

    protected override void Start()
    {
        base.Start();

    }

    //run at swap to this state
    public override void StartState()
    {
        m_navigationAgent.enabled = false;
        m_parentEnemy.m_animator.SetBool("KnockedOut", true);
        StartCoroutine(WakeUp());
    }

    //run each frame, perfom actions
    //Return true when completed
    public override bool UpdateState()
    {
        return m_parentEnemy.m_conscious;
    }

    //run at end of state
    public override void EndState()
    {
        m_parentEnemy.m_animator.SetBool("KnockedOut", false);
    }

    //Is this state valid, e.g. mouse down
    //Return true when valid
    public override bool IsValid()
    {
        return !m_parentEnemy.m_conscious;
    }

    private IEnumerator WakeUp()
    {
        yield return new WaitForSeconds(m_downedTime);
        m_parentEnemy.m_conscious = true;

    }
}
