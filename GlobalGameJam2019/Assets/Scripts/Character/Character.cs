using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement")]
    public float m_movementAcceleration = 1.0f;
    public float m_movementDecelerationPercent = 0.2f;
    public float m_maxSpeed = 1.0f;

    [Header("Model")]
    public GameObject m_model = null;

    protected LayerController m_layerController = null;
        
    protected Rigidbody m_rigidbody = null;
    protected GameManager m_gameManager = null;

    public Animator m_animator = null;
    public CharacterState m_currentState = null;

    public AudioManager m_audioManager = null;

    public bool m_conscious = true;

    protected virtual void Start ()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        m_audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        m_layerController = m_gameManager.GetComponent<LayerController>();

        m_animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {

    }

    protected void SwapStates(CharacterState p_nextState)
    {
        m_currentState.EndState();
        m_currentState = p_nextState;
        m_currentState.StartState();
    }

    public void PlayStep()
    {
        m_audioManager.PlayStep();
    }
}
