using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Fighting/Projectile")]
public class ProjectileItem : ScriptableObject
{
    public float Damage => _damage;

    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Projectile _projectile;

    public void Fire(Vector3 position, Quaternion direction, ShooterType shooterType)
    {
        var createdProjectile = Instantiate<Projectile>(_projectile, position, direction);
        createdProjectile.Launch(_speed, _damage, shooterType);
    }

}
