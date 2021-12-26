using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignBehaviour : BaseBehaviour
{
    [SerializeField] private float _slowRangeDegrees = 10f;

    protected override Steering GetSteering()
    {
        float rotationDiference = transform.rotation.eulerAngles.z - _target.rotation.eulerAngles.z;
        rotationDiference = MapToRotation(rotationDiference);

        float t = Mathf.InverseLerp(-_slowRangeDegrees, _slowRangeDegrees, rotationDiference);
        float rotationCommand = Mathf.Lerp(-1, 1, t);

        var steering = new Steering();
        steering.Rotation = Mathf.Clamp(rotationCommand, -1, 1 );
        return steering;
    }
}
