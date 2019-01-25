using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownBottle : MonoBehaviour
{
    private float m_rotationSpeed = 360.0f;
    private LayerController m_layerController = null;
    private void Start()
    {
        m_layerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LayerController>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.right, m_rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == m_layerController.m_enemyMask)
        {
            other.gameObject.GetComponent<Enemy>().SoberDown();
            Destroy(gameObject);
        }
        if (other.gameObject.layer == m_layerController.m_enviromentMask)
        {
            Destroy(gameObject);
        }
    }
}
