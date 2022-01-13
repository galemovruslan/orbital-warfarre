using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public ProjectilePool Pool { private get; set; }

    [SerializeField] private float _lifeTimeSeconds = 5f;

    private Rigidbody2D _rigidbody;
    private ShooterType _type;
    private float _damage;
    private float _lifeDuration = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _lifeDuration = 0;
    }

    private void Update()
    {
        UpdateLifeTime();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DoDamage(collision.gameObject, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Shooter>(out Shooter shooter))
        {
            if (shooter.Type == _type)
            {
                return;
            }
        }
        if (collision.gameObject.TryGetComponent<Health>(out Health target))
        {
            target.TakeDamage(_damage);
            Pool.ReturnItem(this);
        }
    }

    private void UpdateLifeTime()
    {
        _lifeDuration += Time.deltaTime;
        if (_lifeDuration >= _lifeTimeSeconds)
        {
            Pool.ReturnItem(this);
        }
    }

    private void DoDamage(GameObject collision, bool isTrigger)
    {
        if (collision.gameObject.TryGetComponent<Shooter>(out Shooter shooter))
        {
            if (shooter.Type == _type)
            {
                return;
            }
        }

        if (collision.gameObject.TryGetComponent<Health>(out Health target))
        {
            target.TakeDamage(_damage);
            if (isTrigger)
            {
                Pool.ReturnItem(this);
                return;
            }
        }

        Pool.ReturnItem(this);
    }

    public void Launch(float speed, float damage, ShooterType shooterType)
    {
        _damage = damage;
        _rigidbody.velocity = transform.right * speed;
        _type = shooterType;
    }

}
