using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    private LayerController m_layerController = null;

    private AudioSource m_launch;

    [SerializeField]
    private AudioClip m_escapePod;

    public GameManager m_gameManager = null;
    private GameWin m_gameWin = null;
    void Start()
    {

        m_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        m_gameWin = GameObject.FindGameObjectWithTag("UI").GetComponent<GameWin>();
        m_layerController = m_gameManager.GetComponent<LayerController>();
        m_launch = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == m_layerController.m_playerMask) //End of level
        {
            m_gameManager.m_endGame = true;
            m_gameWin.ShowWinScreen();
            m_launch.PlayOneShot(m_escapePod);
        }
    }
}
