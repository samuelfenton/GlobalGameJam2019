using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public int m_planeMask = 0;
    public int m_playerMask = 0;
    public int m_enemyMask = 0;
    public int m_enviromentMask = 0;
    private void Start()
    {
        m_planeMask = LayerMask.NameToLayer("MousePlane");
        m_playerMask = LayerMask.NameToLayer("Player");
        m_enemyMask = LayerMask.NameToLayer("Enemy");
        m_enviromentMask = LayerMask.NameToLayer("Enviroment");
    }
}
