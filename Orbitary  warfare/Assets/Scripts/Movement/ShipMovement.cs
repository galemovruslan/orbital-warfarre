using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] float _thrustPower = 10f;
    [SerializeField] float _rotationSpeed = 30f;
    [SerializeField] float _maxSpeed = 10f;

    private IGiveControl _controler;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _controler = GetComponent<IGiveControl>();
    }

    private void FixedUpdate()
    {
        AddThrust();
        AddRotation();
        ConstraintSpeed();
    }

    private void AddThrust()
    {
        ShipControlSignals controlSignals = _controler.GetControlSignals();
        float thrustNormalized = Mathf.Max(0, controlSignals.thrust);
        _rigidbody.AddRelativeForce(thrustNormalized * _thrustPower * Vector3.right);
    }

    private void AddRotation()
    {
        ShipControlSignals controlSignals = _controler.GetControlSignals();
        float rotationAmount = controlSignals.rotation * _rotationSpeed * Time.deltaTime;
        Quaternion rotationOffset = Quaternion.Euler(0, 0, -rotationAmount);
        transform.rotation = transform.rotation * rotationOffset;
        _rigidbody.AddTorque(0);
    }

    private void ConstraintSpeed()
    {
        Vector3 currentVelocity = _rigidbody.velocity;
        if (currentVelocity.magnitude > _maxSpeed)
        {
            _rigidbody.velocity = currentVelocity.normalized * _maxSpeed;
        }
    }

}
