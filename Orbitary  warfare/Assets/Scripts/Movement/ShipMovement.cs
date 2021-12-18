using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] float _thrustPower = 10f;
    [SerializeField] float _rotationSpeed = 30f;
    [SerializeField] float _maxSpeed = 10f;

    private Rigidbody2D _rigidbody;

    private float _currentThrust;
    private float _currentRotate;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        AddThrust(_currentThrust);
        AddRotation(_currentRotate);
        ConstraintSpeed();
    }

    public void Move(float thrust, float rotation)
    {
        _currentThrust = thrust;
        _currentRotate = rotation;
    }

    private void AddThrust(float thrust)
    {
        float thrustNormalized = Mathf.Max(0, thrust);
        _rigidbody.AddRelativeForce(thrustNormalized * _thrustPower * Vector3.right);
    }

    private void AddRotation(float rotation)
    {
        float rotationAmount = rotation * _rotationSpeed * Time.deltaTime;
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
