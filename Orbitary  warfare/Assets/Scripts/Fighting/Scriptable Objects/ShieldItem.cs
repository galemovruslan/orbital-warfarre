using UnityEngine;

[CreateAssetMenu(fileName ="New Shield", menuName ="Fighting/Shield")]
public class ShieldItem : ScriptableObject
{
    [SerializeField] int _level;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _durability;

    public int Level { get =>_level; }
    public Sprite Sprite { get => _sprite; }
    public float Durability { get => _durability; }

}
