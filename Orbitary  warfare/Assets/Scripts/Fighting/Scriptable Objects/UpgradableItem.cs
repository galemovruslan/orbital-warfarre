using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradableItem : ScriptableObject
{
    [SerializeField] protected int _level;
    public int Level { get => _level; }

}
