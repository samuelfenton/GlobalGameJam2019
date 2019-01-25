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

    List<GameObject> m_Control = new List<GameObject>();


    float m_Time = 0;

	// Use this for initialization
	void Awake ()
    {
        Agent = GetComponent<NavMeshAgent>();
        Sight();

    }
	
	// Update is called once per frame
	void Update ()
    {
        Sight();

     

        

        switch(Value)
        {
            case 0:
                int i = 0;
                if(i == m_Control.Count + 1 )
                    {
                        i = 0;
                    }

                 Agent.destination = m_Control[i].transform.position;

                if(transform.position == m_Control[i].transform.position)
                ++i;

                break;
            case 1:
                Agent.destination = m_Player.transform.position;
                break;
            case 2:
                m_Time += Time.deltaTime;

                if(m_Time <= 3.5)
                {
                    Agent.destination = transform.position;
                }
                else
                {
                    Value = 0;
                }

                break;
           
        }
        
    }


    void Sight()
    {

       float Dist = Vector3.Distance(m_Player.transform.position, transform.position);

        if (Dist <= 10)
        {
            Value = 0;
        }
        else if(Dist > 10)
        {
            Value = 1;
        }
        
    }

   public void SoberDown()
    {
        Value = 2;
    }
}
