using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class AIShooter : MonoBehaviour
{
    [SerializeField] private float _angleRange = 5f;

    private Shooter _shooter;

    private float _cosAngleRange;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        _cosAngleRange = Mathf.Cos(_angleRange * Mathf.Deg2Rad);
    }

    public void TryShoot( Vector3 targetPosition)
    {
        Vector3 toTargetDirection = (targetPosition - transform.position).normalized;
        float cosToTarget = Vector3.Dot(transform.right, toTargetDirection);
        if(cosToTarget > _cosAngleRange)
        {
            _shooter.Shoot(true);
        } 
    }


}
