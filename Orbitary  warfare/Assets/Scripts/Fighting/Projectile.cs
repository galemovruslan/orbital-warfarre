using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _damage;
    private ShooterType _type;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Shooter>(out Shooter shooter))
        {
            if(shooter.Type == _type) 
            {
                return;
            }
        }

        if(collision.gameObject.TryGetComponent<Health>(out Health target))
        {
            target.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }

    public void Launch(float speed, float damage, ShooterType shooterType)
    {
        _damage = damage;
        _rigidbody.velocity = transform.right * speed;
        _type = shooterType;
    }

}
