using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipMovement))]
public class AIAgent : MonoBehaviour
{

    public Vector3 Velocity => _movement.Velocity;

    private ShipMovement _movement;

    private float _thrustCommand = 0;
    private float _rotateCommand = 0;

    private void Awake()
    {
        _movement = GetComponent<ShipMovement>();
    }

    private void FixedUpdate()
    {
        _movement.Move(_thrustCommand, _rotateCommand);
    }

    public void SetCommand(Steering steering)
    {
        float thrustFromVelocity = Mathf.Clamp01(steering.Thrust.magnitude);

        Vector3 steeringNorm = steering.Thrust.normalized;
        float rotationDifference = Vector3.SignedAngle(steeringNorm, transform.right,  Vector3.forward);

        float remapedRotation = rotationDifference.Remap(-5, 5);
        float totalRotation = remapedRotation + steering.Rotation;

        _thrustCommand = (1 - steering.Weight) * _thrustCommand + steering.Weight * thrustFromVelocity;
        _rotateCommand = (1 - steering.Weight) * _rotateCommand + steering.Weight * totalRotation;
    }

}
