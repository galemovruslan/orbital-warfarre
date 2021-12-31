using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignBehaviour : AgentBehaviour
{
    [SerializeField] private float _slowRangeDegrees = 10f;

    protected override Steering GetSteering()
    {
        float rotationDiference = transform.rotation.eulerAngles.z - _target.rotation.eulerAngles.z;
        rotationDiference = MapToRotation(rotationDiference);

        float t = rotationDiference.Remap(-_slowRangeDegrees, _slowRangeDegrees);
        float rotationCommand = Mathf.Lerp(-1, 1, t);

        var steering = new Steering();
        steering.Rotation = Mathf.Clamp(rotationCommand, -1, 1 );
        return steering;
    }
}
