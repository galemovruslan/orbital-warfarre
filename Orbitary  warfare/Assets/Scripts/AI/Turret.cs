using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, ITargetHelper
{
    [SerializeField] Transform _defaultTarget;

    private AgentBehaviour _behaviour;


    private void Start()
    {
        _behaviour = GetComponent<AgentBehaviour>();
        _behaviour.SetNewTarget(_defaultTarget);
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
