using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float Mass => _mass;
    public float GravityConstant => _gravityConstant;

    [SerializeField] bool isStatic = false;
    [Min(0.1f)]
    [SerializeField] private float _mass;
    [SerializeField] private Gravity _other;
    [SerializeField] private float _gravityConstant = 1f;
    [SerializeField] private float _orbitalForce = 1f;

    private Rigidbody2D _rigidbody;
    private Vector3 totalForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.AddForce(CalculateOrbitalForce(), ForceMode2D.Force);
    }


    private void FixedUpdate()
    {
        if (isStatic) { return; }

        totalForce = Vector3.zero;

        totalForce += CalculateGravityForce();
        _rigidbody.AddForce(totalForce, ForceMode2D.Force);
    }

    private Vector3 CalculateGravityForce()
    {
        float bodyDistance = Vector3.Distance(transform.position, _other.transform.position);
        float force = _other.GravityConstant * (_mass * _other.Mass) / (bodyDistance * bodyDistance + Mathf.Epsilon);

        Vector3 toOther = (_other.transform.position - transform.position).normalized;
        return toOther * force;
    }

    private Vector3 CalculateOrbitalForce()
    {
        Vector3 toOther = (_other.transform.position - transform.position).normalized;
        Vector3 tangentToOther = Vector3.Cross(Vector3.forward, toOther).normalized;
        return tangentToOther * _orbitalForce;
    }

}
