using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FaceBehaviour))]
public class Turret : Enemy
{

    protected override void Awake()
    {
        base.Awake();
        _defaultTarget = new GameObject($"{name}'s default target").transform;
        _defaultTarget.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.right * 10;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 100);
    }

}
