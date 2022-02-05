using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _speed = 1f;

    private float _radius;
    private float _offset = 0f;
    private float _timer;

    private void Start()
    {
        var toMe = transform.position - _center.position;
        _offset = Mathf.Atan2(toMe.y, toMe.x);
        _radius = toMe.magnitude;
    }

    void Update()
    {
        Vector3 newPosition = _center.position;
        _timer += Time.deltaTime* _speed;

        newPosition.x += _radius * Mathf.Cos(_timer + _offset);
        newPosition.y += _radius * Mathf.Sin(_timer + _offset);
        
        transform.position = newPosition; 
    }
}
