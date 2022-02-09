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
        DoDamage(collision.gameObject, isTrigger: false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoDamage(collision.gameObject, isTrigger: true);
    }

    private void UpdateLifeTime()
    {
        _lifeDuration += Time.deltaTime;
        if (_lifeDuration >= _lifeTimeSeconds)
        {
            DestroySelf();
        }
    }

    private void DoDamage(GameObject collision, bool isTrigger)
    {
        if (collision.gameObject.TryGetComponent<IHaveShooterType>(out IHaveShooterType typed))
        {
            if (typed.Type == _type) { return; }
        }

        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
        {
            target.TakeDamage(_damage);
            if (isTrigger)
            {
                DestroySelf();
                return;
            }
        }
        if (!isTrigger)
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        if (Pool == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Pool.ReturnItem(this);
        }
    }

    public void Launch(float speed, float damage, ShooterType shooterType)
    {
        _damage = damage;
        _rigidbody.velocity = transform.right * speed;
        _type = shooterType;
    }

}
