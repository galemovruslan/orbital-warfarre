using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Fighting/Weapon")]
public class Weapon : ScriptableObject
{
    public float TimeBetweenShots => _fireTime;



    [SerializeField] private float _fireTime = 1f;
    [SerializeField] private Projectile _projectile;

    private float nextFireTime = 0f;
    

    public void Fire(Vector3 position, Quaternion direction)
    {
        if(Time.time >= nextFireTime)
        {
            _projectile.Fire(position, direction);
            nextFireTime = Time.time + _fireTime;
        } 
    }



}
