using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FreeForceAdd : MonoBehaviour
{
    [SerializeField] private Vector3 _freeForce;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        AddForce(_freeForce);
    }

    public void AddForce(Vector3 force)
    {
        _rigidbody.AddForce(force);
    }

}
