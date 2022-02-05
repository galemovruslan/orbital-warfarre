using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public abstract class AgentBehaviour : MonoBehaviour
{
    [SerializeField] protected Transform _target;
    [Range(0, 1)]
    [SerializeField] protected float _weight = 1f;

    protected Vector3 _velocity => _agent.Velocity;
    protected GameObject _auxTargetParent;

    private readonly string _auxTargetParentName = "Target Parent";
    private AIAgent _agent;

    protected virtual void Awake()
    {
        _auxTargetParent = GameObject.Find(_auxTargetParentName);
        if (_auxTargetParent == null)
        {
            _auxTargetParent = new GameObject(_auxTargetParentName);
        }
        _agent = GetComponent<AIAgent>();
    }

    private void Update()
    {
        var steering = GetSteering();
        steering.Weight = _weight;
        _agent.SetCommand(steering);
    }

    protected abstract Steering GetSteering();

    public virtual void SetNewTarget(Transform newTarget)
    {
        _target = newTarget;
    }

    public float MapToRotation(float rotation)
    {
        rotation %= 360f;
        if (Mathf.Abs(rotation) > 180f)
        {
            if (rotation < 0)
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
