using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{

    [SerializeField]
    private Transform m_Player;

    [SerializeField]
    private NavMeshAgent Agent;

    private int Value;

    [SerializeField]
    private int m_SightLength;

    private float speed;

    private float accel;

    [SerializeField]
    private float Rotspeed;

    [SerializeField]
    private List<GameObject> m_Control = new List<GameObject>();

    private int i;

    private float m_Time = 0;

    // Use this for initialization
    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Sight();

        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Sight();



        speed = m_maxSpeed;

        accel = m_movementAcceleration;

        Agent.speed = speed;
        Agent.acceleration = accel;
        Agent.angularSpeed = Rotspeed;

        switch (Value)
        {

            case 0:

                Agent.destination = m_Control[i].transform.position;

                if ((transform.position.x == m_Control[i].transform.position.x) & (transform.position.z == m_Control[i].transform.position.z))
                    ++i;

                if (i >= (m_Control.Count))
                    i = 0;

                Debug.Log(i);


                break;
            case 1:
                Agent.destination = m_Player.transform.position;
                break;
            case 2:
                m_Time += Time.deltaTime;

                if (m_Time <= 3.5)
                {
                    Agent.destination = transform.position;
                }
                else
                {
                    Value = 0;
                    m_Time = 0;
                }

                break;


        }

    }


    void Sight()
    {

        float Dist = Vector3.Distance(m_Player.transform.position, transform.position);

        if (Dist >= m_SightLength & Value != 2)
        {
            Value = 0;
        }
        else if (Dist < m_SightLength & Value != 2)
        {
            Value = 1;
        }

    }

    public void SoberDown()
    {
        Value = 2;
    }
}
