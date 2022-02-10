using UnityEngine;

public class StatisticsTime : StaticticBase
{
    protected override void DisplayText()
    {
        int hours = (int)_value / 3600;
        int minutes = (int)_value / 60;
        int seconds = Mathf.RoundToInt(_value % 60);

        _statisticsText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds) ;
    }

    protected override float ProcessNewValue(int value)
    {
        return _value + value / 100;
    }

}
