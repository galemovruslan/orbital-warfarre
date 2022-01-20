using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwapableItem : ScriptableObject
{
    public int Level { get => _level; }
    public Color Color { get => _color; }
    public Sprite Sprite { get => _sprite; }

    [SerializeField] protected int _level;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _color;

}
