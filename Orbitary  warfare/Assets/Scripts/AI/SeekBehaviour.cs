using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : AgentBehaviour
{

    [SerializeField] private float _slowDistance = 5f;
    [SerializeField] private float _stopRadius = .1f;

    protected override Steering GetSteering()
    {
        if(_target == null) 
        { 
            return new Steering(); 
        }

        Vector3 toTarget = _target.position - transform.position;

        if (toTarget.magnitude < _slowDistance)
        {
            float maxVelocity = toTarget.magnitude / _slowDistance;
            toTarget = toTarget.normalized * maxVelocity;
        }
        
        if(toTarget.magnitude < _stopRadius)
        {
            toTarget = toTarget.normalized * 0.0001f;
        }

        Steering steering = new Steering(toTarget, 0);
        return steering;
    }
}
