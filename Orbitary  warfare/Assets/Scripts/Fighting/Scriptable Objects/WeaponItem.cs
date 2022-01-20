using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Fighting/Weapon")]
public class WeaponItem : SwapableItem
{
    public float TimeBetweenShots => _fireTime;
    public WeaponType Type { get => _type;  }

    [SerializeField] private float _fireTime = 1f;
    [SerializeField] private WeaponType _type;


}

public enum WeaponType
{
    Balistic,
    Energy
}