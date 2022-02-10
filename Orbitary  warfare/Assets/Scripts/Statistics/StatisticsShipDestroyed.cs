using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsShipDestroyed : StaticticBase
{
    protected override void DisplayText()
    {
        _statisticsText.text = _value.ToString();
    }

    protected override float ProcessNewValue(int value)
    {
        return ++_value;
    }
}
