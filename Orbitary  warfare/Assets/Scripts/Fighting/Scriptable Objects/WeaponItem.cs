using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Fighting/Weapon")]
public class WeaponItem : SwapableItem
{
    public float TimeBetweenShots => _fireTime;
    public WeaponType Type { get => _type;  }
    public GameObject Visuals { get => _visuals;}

    [SerializeField] private float _fireTime = 1f;
    [SerializeField] private WeaponType _type;
    [SerializeField] private GameObject _visuals;

}

public enum WeaponType
{
    Balistic,
    Energy
}