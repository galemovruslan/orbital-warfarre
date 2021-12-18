using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipMovement))]
public class PlayerControl : MonoBehaviour
{

    private float _thrustComand = 0f;
    private float _rotateComand = 0f;

    private bool _fireComand = false;

    private ShipMovement _movement;
    private Shooter _shooter;

    private void Awake()
    {
        _movement = GetComponent<ShipMovement>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        MoveCommands();
        FireComands();

    }

    private void FireComands()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _fireComand = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            _fireComand = false;
        }

        _shooter.Shoot(_fireComand);
    }

    private void MoveCommands()
    {
        _thrustComand = Input.GetAxis("Vertical");
        _rotateComand = Input.GetAxis("Horizontal");

        _movement.Move(_thrustComand, _rotateComand);
    }
}
