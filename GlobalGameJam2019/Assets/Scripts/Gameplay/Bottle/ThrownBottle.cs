using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownBottle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerController.m_enemyMask)
        {
            collision.gameObject.GetComponent<Enemy>().SoberDown();
        }

        Destroy(gameObject);
    }
}
