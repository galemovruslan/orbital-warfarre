using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintOrientation : MonoBehaviour
{
    [SerializeField] private float _angleMax = 45f;

    private Vector3 _startRotation;
    private void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
    }

    private void LateUpdate()
    {
        Quaternion minRotation = Quaternion.Euler(0, 0, _startRotation.z - _angleMax);
        Quaternion maxRotation = Quaternion.Euler(0, 0, _startRotation.z + _angleMax);

        Quaternion currentOrientation = transform.rotation;

        if(currentOrientation.z > maxRotation.z)
        {
            currentOrientation = maxRotation;
        }
        else if(currentOrientation.z < minRotation.z)
        {
            currentOrientation = minRotation;
        }
        transform.rotation = currentOrientation;
    }

}
