using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DrunkCompanion))]
public class Player : Character
{

    [Header("Drunk stuff")]
    [Tooltip("Minimum time between change in drunk effects")]
    public float m_minDrunkEffectTimer = 5.0f;
    [Tooltip("Maximum time between change in drunk effects")]
    public float m_maxDrunkEffectTimer = 10.0f;
    [Tooltip("Changes how much we force player movement, e.g. 2, player speed is now 2 in vertical/horiztonal at all times ")]
    public float m_additionalInputMultiplier = 1.0f;

    public enum DRUNK_EFFECTS {FLIP_VERT_INPUT, FLIP_HORI_INPUT, ADD_VERT_INPUT, ADD_HORI_INPUT, VIGNETTE, DOF, EFFECT_COUNT }

    public bool[] m_currentDrunkEffects = null;
    public PlayerState m_currentState = null;

    private DrunkCompanion m_drunkCompanion = null;
    private Camera m_mainCamera = null;

    protected override void Start()
    {
        base.Start();

        m_drunkCompanion = GetComponent<DrunkCompanion>();
        m_currentDrunkEffects = new bool[(int)DRUNK_EFFECTS.EFFECT_COUNT];

        m_mainCamera = Camera.main;

        StartCoroutine(GetRandomEffects());
    }

    private void Update ()
    {
        //State Machine!
        if(m_currentState.UpdateState())//State done
        {
            foreach (PlayerState playerState in m_currentState.m_nextStates)
            {
                if(playerState.IsValid())
                {
                    SwapStates(playerState);
                    break;
                }
            }
        }

        //Animations
        m_animator.SetFloat("Speed", m_rigidbody.velocity.magnitude / m_maxSpeed);
        m_animator.SetFloat("Drunkenness", Mathf.Clamp(m_gameManager.nAlcoholBottles / 10.0f,0, 1));
        m_model.transform.LookAt(m_model.transform.position + m_rigidbody.velocity, Vector3.up);

        //Post effects
        m_drunkCompanion.UpdatePostProcesing(m_currentDrunkEffects);
    }

    private IEnumerator GetRandomEffects()
    {
        //Stop for random amount of time
        yield return new WaitForSeconds(Random.Range(m_minDrunkEffectTimer, m_maxDrunkEffectTimer));
        m_currentDrunkEffects = m_gameManager.DetermineDrunkEffects(); // New effects!

        StartCoroutine(GetRandomEffects());
    }

    private void SwapStates(PlayerState p_nextState)
    {
        m_currentState.EndState();
        m_currentState = p_nextState;
        m_currentState.StartState();
    }
}
