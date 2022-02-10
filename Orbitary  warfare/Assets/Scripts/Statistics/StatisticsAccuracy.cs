using UnityEngine;

public class StatisticsAccuracy : StaticticBase
{
    [SerializeField] private EventAsset _onProjectileLand;

    private float _landedProjectiles;

    protected override void Awake()
    {
        _onProjectileLand.AddListener(AddLandedProjectile);
        base.Awake();
    }

    private void AddLandedProjectile(int obj)
    {
        _landedProjectiles++;
    }

    protected override float ProcessNewValue(int value)
    {
        return ++_value;
    }

    protected override void DisplayText()
    {
        _statisticsText.text = string.Format("{0:F1} %", _landedProjectiles / _value * 100);
    }
}
