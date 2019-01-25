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

    public struct DrunkEffects
    {
        public enum ON_OFF {ON = -1, OFF = 1}


        public ON_OFF m_flipVerticalInput;
        public ON_OFF m_flipHorizontalInput;

        public DrunkEffects (ON_OFF p_flipVerticalInput = ON_OFF.OFF, ON_OFF p_flipHorizontalInput = ON_OFF.OFF)
        {
            m_flipVerticalInput = p_flipVerticalInput;
            m_flipHorizontalInput = p_flipHorizontalInput;
        }
    }

    private DrunkEffects m_currentDrunkEffects;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        m_rigidbody = GetComponent<Rigidbody>();


        StartCoroutine(GetRandomEffects());
    }

    // Update is called once per frame
    private void Update ()
    {
        //Basic movemnt
        Vector3 frameVelocity = m_rigidbody.velocity;

        if(Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            frameVelocity.x += Input.GetAxisRaw("Horizontal") * (int)m_currentDrunkEffects.m_flipHorizontalInput * m_movementAcceleration * Time.deltaTime; //speed up
        }
        else
        {
            frameVelocity.x *= m_movementDecelerationPercent; //slow down
        }

        if (Input.GetAxisRaw("Vertical") != 0.0f)
        {
            frameVelocity.z += Input.GetAxisRaw("Vertical") * (int)m_currentDrunkEffects.m_flipVerticalInput * m_movementAcceleration * Time.deltaTime;//speed up
        }
        else
        {
            frameVelocity.z *= m_movementDecelerationPercent;//slow down
        }

        //Cap to max speed
        if(frameVelocity.magnitude > m_maxSpeed)
            frameVelocity = frameVelocity.normalized * m_maxSpeed;

        //Apply velocity
        m_rigidbody.velocity = frameVelocity;
    }

    private IEnumerator GetRandomEffects()
    {
        //Stop for random amount of time
        yield return new WaitForSeconds(Random.Range(m_minDrunkEffectTimer, m_maxDrunkEffectTimer));
        m_currentDrunkEffects = m_gameManager.DetermineDrunkEffects(); // New effects!
        StartCoroutine(GetRandomEffects());
    }
}
