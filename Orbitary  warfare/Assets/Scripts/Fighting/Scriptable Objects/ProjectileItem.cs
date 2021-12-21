using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Fighting/Projectile")]
public class ProjectileItem : ScriptableObject
{
    public float Damage => _damage;
    public float Speed => _speed;
    public Projectile Projectile => _projectile;

    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Projectile _projectile;


}
