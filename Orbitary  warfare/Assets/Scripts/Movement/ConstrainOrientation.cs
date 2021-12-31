using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainOrientation : MonoBehaviour
{
    [SerializeField] private float _angleMax = 45f;

    private void LateUpdate()
    {
        Quaternion minRotation = Quaternion.Euler(0, 0, -_angleMax);
        Quaternion maxRotation = Quaternion.Euler(0, 0, _angleMax);

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
