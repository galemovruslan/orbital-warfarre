using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidBehaviour : SeekBehaviour
{
    [SerializeField] private float _avoidRange = 5f;
    [SerializeField] private Transform _scanStart;
    [Range(0, 135)]
    [SerializeField] private int _rayAngleRange = 90;
    [Range(1, 50)]
    [SerializeField] private int _rayAmount = 5;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _toTargetMaxLength = 10f;

    private Transform _avoidVMarker;

    private Vector3 _avoidVector;
    private float _avoidDecay = 0.9f;
    
    protected override void Awake()
    {
        base.Awake();
        _avoidVMarker = new GameObject($"{name}'s avoidance target ").transform;
        _avoidVMarker.transform.parent = _auxTargetParent.transform;
    }

    protected override Steering GetSteering()
    {
        Vector3 rayStart = _scanStart.position;

        Steering steering = base.GetSteering();
        if (steering.Thrust.magnitude > _toTargetMaxLength)
        {
            steering.Thrust = steering.Thrust.normalized * _toTargetMaxLength;
        }

        Vector3 currentAvoidVector = GetAvoidVector(rayStart);
        if(currentAvoidVector == Vector3.zero)
        {
            _avoidVector *= _avoidDecay;
        }
        else
        {
            _avoidVector = currentAvoidVector;
        }
        steering.Thrust += _avoidVector;
        _avoidVMarker.transform.position = transform.position + steering.Thrust;

        return steering;

    }

    private Vector3 GetAvoidVector(Vector3 rayStart)
    {
        Vector3 avoidDirection = Vector3.zero; ;
        foreach (Vector3 rayDirection in GetRayDirections())
        {
            RaycastHit2D hit = Physics2D.Raycast(
                rayStart,
                rayDirection,
                _avoidRange * Mathf.Sqrt(Vector3.Dot(transform.right, rayDirection)),
                _layerMask);

            if (hit.collider != null)
            {
                Vector3 localAvoidVector = Vector3.zero;
                if (1 - Vector3.Dot(transform.right, rayDirection) <= 0.01f)
                {
                    localAvoidVector = (new Vector3(hit.point.x, hit.point.y) +
                                        new Vector3(hit.normal.y, hit.normal.x) * _avoidRange -
                                        transform.position).normalized;
                }
                else
                {
                    localAvoidVector = (transform.right - rayDirection).normalized;
                }


                avoidDirection += localAvoidVector.normalized;
            }
        }

        return avoidDirection * _avoidRange;
    }

    IEnumerable<Vector3> GetRayDirections()
    {
        if (_rayAmount == 1)
        {
            yield return transform.right;
            yield break;
        }

        float startAngle = -_rayAngleRange;
        float angleOffset = _rayAngleRange * 2 / (_rayAmount - 1);

        for (int rayIndex = 0; rayIndex < _rayAmount; rayIndex++)
        {
            float rayAngle = startAngle + angleOffset * rayIndex;
            Vector3 rayDirection = Quaternion.Euler(0, 0, rayAngle) * transform.right;

            yield return rayDirection;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 rayStart = _scanStart.position;
        foreach (Vector3 rayDirection in GetRayDirections())
        {
            Gizmos.DrawLine(rayStart, rayStart + rayDirection * _avoidRange * Mathf.Sqrt(Vector3.Dot(transform.right, rayDirection)));
        }
    }
}


/*
 * private class Timer
    {
        private float _presetValue;
        private float _timerValue;
        private float _startTime;

        public bool IsDone()
        {
            return _timerValue >= _presetValue;
        }

        public void Start(float newPresetValue)
        {
            _presetValue = newPresetValue;
            _startTime = Time.time;
        }

        public void Tick()
        {
            _timerValue = Time.time - _startTime;
        }
    }
 */
