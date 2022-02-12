using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwapableItem : ScriptableObject
{
    public int Level { get => _level; }

    [SerializeField] protected int _level;

}
