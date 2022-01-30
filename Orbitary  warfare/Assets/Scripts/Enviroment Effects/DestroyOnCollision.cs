using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(10E+6f);
        }
        else if(collision.gameObject.TryGetComponent<Destroyable>(out var destroyable))
        {
            Destroy(collision.gameObject);
        }
    }
}
