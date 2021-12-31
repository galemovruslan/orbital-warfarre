using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvoidBehaviour))]
public class SpaceShip : MonoBehaviour, ITargetHelper
{
    [SerializeField] private Transform _defaultTarget;

    AgentBehaviour _behaviour;

    private void Awake()
    {
        _behaviour = GetComponent<AgentBehaviour>();
        ResetTarget();
    }

    public void ResetTarget()
    {
        _behaviour.SetNewTarget(_defaultTarget);
    }

    public void SetTarget(Transform newTarget)
    {
        _behaviour.SetNewTarget(newTarget);
    }
}
