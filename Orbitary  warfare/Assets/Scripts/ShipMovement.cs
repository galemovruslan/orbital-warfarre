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
        ShipControlSignals controls = _controler.GetControlSignals();
        float thrustClamped = Mathf.Max(0, controls.thrust);
        _rigidbody.AddRelativeForce(thrustClamped * _thrustPower * Vector3.right);
    }

    private void AddRotation()
    {
        ShipControlSignals controls = _controler.GetControlSignals();
        float rotationAmount = controls.rotation * _rotationSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, 0, -rotationAmount);
        transform.rotation = transform.rotation * rotation;
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
