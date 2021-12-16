using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IGiveControl
{

    private float _thrustComand = 0f;
    private float _rotateComand = 0f;

    private void Update()
    {
        _thrustComand = Input.GetAxis("Vertical");
        _rotateComand = Input.GetAxis("Horizontal");
    }

    public ShipControlSignals GetControlSignals()
    {
        return new ShipControlSignals(_rotateComand, _thrustComand);
    }
}
