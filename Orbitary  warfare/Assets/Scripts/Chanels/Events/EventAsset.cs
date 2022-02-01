using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Chanels/Event Asset")]
public class EventAsset : ScriptableObject
{
    private HashSet<Action<int>> _listeners = new HashSet<Action<int>>();

    private void OnEnable()
    {
        _listeners.Clear();
    }

    private void OnDisable()
    {
        _listeners.Clear();
    }

    public void AddListener(Action<int> listener)
    {
        if (_listeners.Contains(listener)) { return; }

        _listeners.Add(listener);
    }

    public void RemoveListener(Action<int> listener)
    {
        if (_listeners.Contains(listener))
        {
            _listeners.Remove(listener);
        }
    }

    public void Invoke(int value)
    {
        foreach (var listener in _listeners)
        {
            listener.Invoke(value);
        }
    }

}
