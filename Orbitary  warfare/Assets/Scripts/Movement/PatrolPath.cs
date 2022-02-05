using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    [SerializeField] private Transform[] _path;
    [SerializeField] private float _speed = 20f;

    private int _currentPointIndex = 0;
    private float _moveTime;
    private float _maxMoveTime = 1f;
    private Vector3 _startPoint;

    private void Update()
    {
        if(_moveTime / _maxMoveTime >= 1)
        {
            _startPoint = _path[_currentPointIndex].position;
            _currentPointIndex++;
            _currentPointIndex %= _path.Length;
            _moveTime = 0;
            _maxMoveTime = Vector3.Distance(_startPoint, _path[_currentPointIndex].position) / _speed;
        }

        _moveTime += Time.deltaTime;
        transform.position = Vector3.Lerp(_startPoint, _path[_currentPointIndex].position, _moveTime/_maxMoveTime);
    }
}
