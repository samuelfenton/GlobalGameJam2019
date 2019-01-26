using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLevelBottle : MonoBehaviour {

    private LayerController m_layerController = null;
    //reference to self gameobject
    private GameObject bottle;

    //score Manager
    public GameManager m_gameManager;

    void Start ()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        m_layerController = m_gameManager.GetComponent<LayerController>();
    }
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == m_layerController.m_playerMask)
        {
            m_gameManager.nAlcoholBottles++;

            Destroy(gameObject);
        }
    }
}
