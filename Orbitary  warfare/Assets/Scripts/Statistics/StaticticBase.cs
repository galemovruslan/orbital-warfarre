using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class StaticticBase : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _statisticsText;
    [SerializeField] private EventAsset _onAddValue;

    protected float _value;

    protected abstract float ProcessNewValue(int value);
    protected abstract void DisplayText();

    protected virtual void Awake()
    {
        _onAddValue.AddListener(AddValue);
    }

    private void OnDestroy()
    {
        _onAddValue.RemoveListener(AddValue);
    }

    private void AddValue(int value)
    {
        _value = ProcessNewValue(value);
        DisplayText();
    }


}
