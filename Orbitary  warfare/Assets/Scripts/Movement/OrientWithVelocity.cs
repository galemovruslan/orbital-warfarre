using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientWithVelocity : MonoBehaviour
{
    Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        _lastPosition = transform.position;
    }

    private void Update()
    {
        Vector3 moveDirection = (transform.position - _lastPosition).normalized;
        float rotation = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
