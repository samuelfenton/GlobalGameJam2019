using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Move : PlayerState
{
    protected Rigidbody m_rigidbody = null;

    protected override void Start()
    {
        base.Start();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    //run at swap to this state
    public override void StartState()
    {

    }

    //run each frame, perfom actions
    //Return true when completed
    public override bool UpdateState()
    {
        //Basic movemnt
        Vector3 frameVelocity = m_rigidbody.velocity;

        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            frameVelocity.x += Input.GetAxisRaw("Horizontal") * (int)m_parentPlayer.m_currentDrunkEffects.m_flipHorizontalInput * m_parentPlayer.m_movementAcceleration * Time.deltaTime; //speed up
        }
        else
        {
            frameVelocity.x *= m_parentPlayer.m_movementDecelerationPercent; //slow down
        }

        if (Input.GetAxisRaw("Vertical") != 0.0f)
        {
            frameVelocity.z += Input.GetAxisRaw("Vertical") * (int)m_parentPlayer.m_currentDrunkEffects.m_flipVerticalInput * m_parentPlayer.m_movementAcceleration * Time.deltaTime;//speed up
        }
        else
        {
            frameVelocity.z *= m_parentPlayer.m_movementDecelerationPercent;//slow down
        }

        //Cap to max speed
        if (frameVelocity.magnitude > m_parentPlayer.m_maxSpeed)
            frameVelocity = frameVelocity.normalized * m_parentPlayer.m_maxSpeed;

        //Apply velocity
        m_rigidbody.velocity = frameVelocity;
        return true;
    }

    //run at end of state
    public override void EndState()
    {

    }

    //Is this state valid, e.g. mouse down
    //Return true when valid
    public override bool IsValid()
    {
        return true;
    }
}
