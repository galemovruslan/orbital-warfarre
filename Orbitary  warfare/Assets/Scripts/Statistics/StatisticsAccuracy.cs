using UnityEngine;

public class StatisticsAccuracy : StaticticBase
{
    [SerializeField] private EventAsset _onProjectileFire;

    private float _firedProjectiles;

    protected override void Awake()
    {
        _onProjectileFire.AddListener(AddFiredProjectile);
        base.Awake();
    }

    private void OnDestroy()
    {
        _onProjectileFire.RemoveListener(AddFiredProjectile);
    }

    private void AddFiredProjectile(int obj)
    {
        _firedProjectiles++;
    }

    protected override float ProcessNewValue(int value)
    {
        return ++_value;
    }

    protected override void DisplayText()
    {
        _statisticsText.text = string.Format("{0:F1}%", _value / _firedProjectiles * 100);
    }
}
