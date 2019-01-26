using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attacking : EnemyState
{
    private GameManager m_gameManager = null;

    public AnimationClip m_attackingAnimation = null;

    private float m_totalAttackTime = 1.0f;

    private bool m_attacking = false;
    private Player m_targetPlayer = null;
    private Gameover m_gameover = null;

    protected override void Start()
    {
        base.Start();
        m_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        m_totalAttackTime = m_attackingAnimation.length * 0.95f;
        m_targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        m_gameover = GameObject.FindGameObjectWithTag("UI").GetComponent<Gameover>();

    }
    //run at swap to this state
    public override void StartState()
    {
        //Attack
        m_navigationAgent.enabled = false;

        m_attacking = true;
        m_parentEnemy.m_animator.SetBool("Grab", true);

        //Face player
        transform.LookAt(m_targetPlayer.transform, Vector3.up);

        m_targetPlayer.m_conscious = false;

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
        m_parentEnemy.m_animator.SetBool("Grab", false);
        m_gameover.gameover();
    }

    //Is this state valid, e.g. mouse down
    //Return true when valid
    public override bool IsValid()
    {
        return m_parentEnemy.m_atackPlayerDistance > Vector3.Distance(m_targetPlayer.transform.position, this.transform.position);
    }

    private IEnumerator AnimationEnded()
    {
        yield return new WaitForSeconds(m_totalAttackTime);
        m_attacking = false;
    }
}
