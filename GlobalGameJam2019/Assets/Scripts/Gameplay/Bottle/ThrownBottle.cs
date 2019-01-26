using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownBottle : MonoBehaviour
{
    private float m_rotationSpeed = 360.0f;
    private LayerController m_layerController = null;
    private Kevin kev = null;

    private AudioManager m_audioManager = null;
    public GameObject m_glassShatterEffect = null;
    private void Start()
    {
        m_layerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LayerController>();
        m_audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
            SmashBottle();
        }
        else if (other.gameObject.layer == m_layerController.m_enviromentMask)
        {
            SmashBottle();
        }
        else if (other.gameObject.layer == m_layerController.m_kevinMask)
        {
            kev.Headkevin();
            SmashBottle();
        }
    }

    private void SmashBottle()
    {
        GameObject bottleSmash = Instantiate(m_glassShatterEffect);

        bottleSmash.transform.position = transform.position;
        bottleSmash.transform.LookAt(transform.position - GetComponent<Rigidbody>().velocity);

        m_audioManager.PlayGlassSmash();
        Destroy(gameObject);
    }
}
