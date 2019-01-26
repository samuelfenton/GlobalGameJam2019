using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [HideInInspector]
    public Player m_parentPlayer = null;
    public List<PlayerState> m_nextStates = new List<PlayerState>();
    protected LayerController m_layerController = null;

    protected virtual void Start()
    {
        m_parentPlayer = GetComponent<Player>();
        m_layerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LayerController>();
    }

    //run at swap to this state
    public virtual void StartState()
    {

    }

    //run each frame, perfom actions
    //Return true when completed
    public virtual bool UpdateState()
    {
        return false;
    }

    //run at end of state
    public virtual void EndState()
    {

    }

    //Is this state valid, e.g. mouse down
    //Return true when valid
    public virtual bool IsValid()
    {
        return false;
    }
}
