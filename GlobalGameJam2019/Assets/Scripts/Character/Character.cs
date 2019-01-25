using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement")]
    public float m_movementAcceleration = 1.0f;
    public float m_movementDecelerationPercent = 0.2f;
    public float m_maxSpeed = 1.0f;

    protected Rigidbody m_rigidbody = null;
    protected virtual void Start ()
    {
        m_rigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
