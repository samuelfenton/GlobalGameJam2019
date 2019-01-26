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
        Vector3 frameVelocity = new Vector3();
        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            frameVelocity.x += Input.GetAxisRaw("Horizontal") * m_parentPlayer.m_movementAcceleration * Time.deltaTime; //speed up
            if (m_parentPlayer.m_currentDrunkEffects[(int)Player.DRUNK_EFFECTS.FLIP_HORI_INPUT])
                frameVelocity.x *= -1;

            if (m_parentPlayer.m_currentDrunkEffects[(int)Player.DRUNK_EFFECTS.ADD_HORI_INPUT])
                frameVelocity.x *= m_parentPlayer.m_additionalInputMultiplier; 
        }
        else
        {
            frameVelocity.x *= m_parentPlayer.m_movementDecelerationPercent; //slow down
        }

        if (Input.GetAxisRaw("Vertical") != 0.0f)
        {
            frameVelocity.z += Input.GetAxisRaw("Vertical") * m_parentPlayer.m_movementAcceleration * Time.deltaTime;//speed up
            if (m_parentPlayer.m_currentDrunkEffects[(int)Player.DRUNK_EFFECTS.FLIP_VERT_INPUT])
                frameVelocity.z *= -1;

            if (m_parentPlayer.m_currentDrunkEffects[(int)Player.DRUNK_EFFECTS.ADD_HORI_INPUT])
                frameVelocity.x *= m_parentPlayer.m_additionalInputMultiplier;
        }
        else
        {
            frameVelocity.z *= m_parentPlayer.m_movementDecelerationPercent;//slow down
        }

        //Cap to max speed
        frameVelocity += m_rigidbody.velocity;

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
