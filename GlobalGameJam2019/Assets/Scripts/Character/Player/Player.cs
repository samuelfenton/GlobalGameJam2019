using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public struct DrunkEffects
    {
        public int m_flipVerticalInput;
        public int m_flipHorizontalInput;

        public DrunkEffects (int p_flipVerticalInput, int p_flipHorizontalInput)
        {
            m_flipVerticalInput = p_flipVerticalInput;
            m_flipHorizontalInput = p_flipHorizontalInput;
        }
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        m_rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    private void Update ()
    {
        //Basic movemnt
        Vector3 frameVelocity = m_rigidbody.velocity;

        if(Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            frameVelocity.x += Input.GetAxisRaw("Horizontal") * m_movementAcceleration * Time.deltaTime; //speed up
        }
        else
        {
            frameVelocity.x *= m_movementDecelerationPercent; //slow down
        }

        if (Input.GetAxisRaw("Vertical") != 0.0f)
        {
            frameVelocity.z += Input.GetAxisRaw("Vertical") * m_movementAcceleration * Time.deltaTime;//speed up
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

    private DrunkEffects DetermineDrunkEffects()
    {
        DrunkEffects currentDrunkenness = new DrunkEffects();
        //Do magic here


        return currentDrunkenness;
    }
}
