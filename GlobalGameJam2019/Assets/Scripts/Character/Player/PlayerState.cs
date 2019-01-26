using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : CharacterState
{
    [HideInInspector]
    public Player m_parentPlayer = null;

    protected override void Start()
    {
        base.Start();
        m_parentPlayer = GetComponent<Player>();
    }
}
