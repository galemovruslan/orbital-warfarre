using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintOrientation : MonoBehaviour
{
    [SerializeField] private float _angleMax = 45f;

    private float _startRotation;
    private void Awake()
    {
        _startRotation = MapToRotation(transform.rotation.eulerAngles.z,true);
    }

    private void LateUpdate()
    {
        float minRotationAngle = _startRotation - _angleMax;
        float maxRotationAngle = _startRotation + _angleMax;

        Quaternion minRotation = Quaternion.Euler(0, 0, minRotationAngle);
        Quaternion maxRotation = Quaternion.Euler(0, 0, maxRotationAngle);

        Quaternion currentOrientation = transform.rotation;

        float currentAngle = MapToRotation(currentOrientation.eulerAngles.z, true);

        if (currentAngle > maxRotationAngle)
        {
            currentOrientation = maxRotation;
        }
        else if(currentAngle < minRotationAngle)
        {
            currentOrientation = minRotation;
        }
        transform.rotation = currentOrientation;
    }

    public float MapToRotation(float rotation, bool isConstraint)
    {
        rotation %= 360f;
        
        if(Mathf.Abs(_startRotation) > _angleMax)
        {
            if(Mathf.Sign(rotation) != Mathf.Sign(_startRotation))
            {
                if (rotation < 0)
                {
                    rotation += 360f;
                }
                else
                {
                    rotation -= 360f;
                }
            }
            return rotation;
        }
        
        if (Mathf.Abs(rotation) > 180F)
        {
            if (rotation < 0)
            {
                rotation += 360f;
            }
            else
            {
                rotation -= 360f;
            }
        }
        return rotation;
    }

}
