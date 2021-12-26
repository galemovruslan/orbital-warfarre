using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravitator : MonoBehaviour
{

    [SerializeField] private float _mass = 100f;
    [SerializeField] private float _gravityConstant = 1f;
    [SerializeField] private float _effectRadius = 5f;
    [SerializeField] private CircleCollider2D _effectCollider;

    private HashSet<Gravitable> effectedGravitables = new HashSet<Gravitable>();

    private void OnValidate()
    {
        _effectCollider.radius = _effectRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _effectRadius*2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Gravitable>(out Gravitable gravitable))
        {
            effectedGravitables.Add(gravitable);
            //Debug.Log($"Added {gravitable.name}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Gravitable>(out Gravitable gravitable))
        {
            effectedGravitables.Remove(gravitable);
            //Debug.Log($"Removed {gravitable.name}");
        }
    }

    private void FixedUpdate()
    {
        foreach (var gravitable in effectedGravitables)
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

}
