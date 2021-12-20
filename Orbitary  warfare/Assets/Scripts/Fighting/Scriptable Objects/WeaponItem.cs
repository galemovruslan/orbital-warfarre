using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Fighting/Weapon")]
public class WeaponItem : ScriptableObject
{
    public float TimeBetweenShots => _fireTime;

    [SerializeField] private float _fireTime = 1f;
    
}
