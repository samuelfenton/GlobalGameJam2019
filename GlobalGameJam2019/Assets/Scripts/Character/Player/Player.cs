using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        m_rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update ()
    {
        //Basic movemnt
        Vector3 frameVelocity = m_rigidbody.velocity + new Vector3(Input.GetAxisRaw("Horizontal") * m_movementAcceleration, 0.0f, Input.GetAxisRaw("Vertical") * m_movementAcceleration) * Time.deltaTime;

        frameVelocity = frameVelocity.normalized * m_maxSpeed;

        m_rigidbody.velocity = frameVelocity;
    }
}
