using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [Header("Drunk stuff")]
    [Tooltip("Minimum time between change in drunk effects")]
    public float m_minDrunkEffectTimer = 5.0f;
    [Tooltip("Maximum time between change in drunk effects")]
    public float m_maxDrunkEffectTimer = 10.0f; 

    public class DrunkEffects
    {
        public enum ON_OFF {ON = -1, OFF = 1}

        public ON_OFF m_flipVerticalInput = ON_OFF.OFF;
        public ON_OFF m_flipHorizontalInput = ON_OFF.OFF;
    }

    public DrunkEffects m_currentDrunkEffects;
    public PlayerState m_currentState = null;

    private Camera m_mainCamera = null;
    int m_planeMask = LayerMask.NameToLayer("MousePlane");

    protected override void Start()
    {
        base.Start();

        m_rigidbody = GetComponent<Rigidbody>();

        m_currentDrunkEffects = new DrunkEffects();
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

        //Apply model rotation, mouse dir 
        //TODO, doesnt work
        Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, m_planeMask))
        {
            //one of coordiantes being always zero for aligned plane
            Vector3 mousePos = hit.point;//this is relative to 0,0,0

            Vector3 mouseToPlayer =  mousePos - transform.position;
            mouseToPlayer.y = 0;

            //Face only when greater than a very smaller number
            if(mouseToPlayer.magnitude > float.Epsilon)
                m_model.transform.LookAt(transform.position + mouseToPlayer, Vector3.up);
        }
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
