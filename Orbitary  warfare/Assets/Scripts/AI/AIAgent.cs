using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipMovement))]
public class AIAgent : MonoBehaviour
{

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

    public void SetMove(Steering steering)
    {
        _thrustCommand = steering.Thrust;
        _rotateCommand = steering.Rotation;
    }

}
