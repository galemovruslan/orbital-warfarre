using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public abstract class BaseBehaviour : MonoBehaviour
{
    [SerializeField] protected Transform _target;

    private AIAgent _agent;

    protected virtual void Awake()
    {
        _agent = GetComponent<AIAgent>();
    }

    private void Update()
    {
        _agent.SetMove(GetSteering());
    }

    protected abstract Steering GetSteering();

    public float MapToRotation(float rotation)
    {
        rotation %= 360f;
        if (Mathf.Abs(rotation) > 180f)
        {
            if(rotation < 0)
            {
                rotation += 360f;
            }
            else
            {
                rotation -= 360f;
            }
        }
        return rotation;
    }

}
