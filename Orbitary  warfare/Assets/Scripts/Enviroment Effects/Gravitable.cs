using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravitable : MonoBehaviour
{
    public event Action<Gravitable> BeforeDestroy;

    Vector3 _velocity = Vector3.zero;

    public float Mass => _mass;

    [SerializeField] private float _mass;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        BeforeDestroy?.Invoke(this);
    }

    public void ApplyForce(Vector3 force)
    {
        _rigidbody.AddForce(force);
    }

}
