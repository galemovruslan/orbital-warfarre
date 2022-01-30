using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravitator : MonoBehaviour
{
    [Header("Gravity effect")]
    [SerializeField] private float _mass = 100f;
    [SerializeField] private float _gravityConstant = 1f;
    [Header("Effected area")]
    [SerializeField] private float _effectRadius = 5f;
    [SerializeField] private CircleCollider2D _effectCollider;
    [Header("Visuals")]
    [SerializeField] private float _surfaceRadius = 1f;
    [SerializeField] private Transform _visuals;
    [SerializeField] private CircleCollider2D _surfaceCollider;

    private HashSet<Gravitable> _effectedGravitables = new HashSet<Gravitable>();

    private void OnValidate()
    {
        _effectCollider.radius = _effectRadius;
        _surfaceCollider.radius = _surfaceRadius / 2;
        _visuals.localScale = new Vector3(_surfaceRadius, _surfaceRadius, 1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _effectRadius );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Gravitable>(out Gravitable gravitable))
        {
            _effectedGravitables.Add(gravitable);
            gravitable.BeforeDestroy += RemoveGravitable;
            //if (collision.TryGetComponent<Health>(out Health health))
            //{
            //    health.OnDestroy += DeleteFromEffected;
            //}
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Gravitable>(out Gravitable gravitable))
        {
            _effectedGravitables.Remove(gravitable);
            gravitable.BeforeDestroy -= RemoveGravitable;
            //if (collision.TryGetComponent<Health>(out Health health))
            //{
            //    health.OnDestroy -= DeleteFromEffected;
            //}
        }
    }

    private void FixedUpdate()
    {
        foreach (var gravitable in _effectedGravitables)
        {
            gravitable.ApplyForce(CalculateGravityForce(gravitable));
        }
    }

    private Vector3 CalculateGravityForce(Gravitable effectedBody)
    {
        float bodyDistance = Vector3.Distance(transform.position, effectedBody.transform.position);
        float force = _gravityConstant * (_mass * effectedBody.Mass) / (bodyDistance * bodyDistance + Mathf.Epsilon);

        Vector3 toThis = (transform.position - effectedBody.transform.position).normalized;
        return toThis * force;
    }

    private void DeleteFromEffected(GameObject go)
    {
        _effectedGravitables.Remove(go.GetComponent<Gravitable>());
    }

    private void RemoveGravitable(Gravitable gravitable)
    {
        _effectedGravitables.Remove(gravitable);
        gravitable.BeforeDestroy -= RemoveGravitable;
    }

}
