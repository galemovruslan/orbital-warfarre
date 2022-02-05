using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBehaviour : AlignBehaviour
{

    private Transform _faceTarget;

    protected override void Awake()
    {
        base.Awake();
        _faceTarget = _target;
        _target = new GameObject($"{name}'s target Aux").transform;
        _target.parent = _auxTargetParent.transform;
    }

    private void OnDestroy()
    {
        if (_target != null)
        {
            Destroy(_target.gameObject);

        }
    }

    protected override Steering GetSteering()
    {
        Vector3 lookDirection = (_faceTarget.position - transform.position).normalized;
        float rotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        _target.rotation = Quaternion.Euler(0, 0, rotation);

        Steering steering = base.GetSteering();
        return steering;
    }

    public override void SetNewTarget(Transform newTarget)
    {
        _faceTarget = newTarget;
    }

}
