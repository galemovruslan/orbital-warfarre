using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Fighting/Projectile")]
public class Projectile : ScriptableObject
{
    public float Damage => _damage;

    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody2D _prefab;

    public void Fire(Vector3 position, Quaternion direction)
    {
        var createdProjectile = Instantiate<Rigidbody2D>(_prefab, position, direction);
        createdProjectile.velocity = createdProjectile.transform.right * _speed;
    }



}
