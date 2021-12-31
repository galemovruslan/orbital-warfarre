using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentBehaviour))]
public class AvoidModifier : MonoBehaviour
{

    private AgentBehaviour _behaviour;

    private void Awake()
    {
        _behaviour = GetComponent<AgentBehaviour>();
    }

    private void FixedUpdate()
    {
        
    }

}
