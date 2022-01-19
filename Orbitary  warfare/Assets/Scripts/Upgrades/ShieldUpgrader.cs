
public class ShieldUpgrader : UpgraderBase
{
    protected override void ApplyUpgrade(UpgradableTag upgradable)
    {
        if(upgradable.TryGetComponent<Shield>(out var shield))
        {
            shield.LevelUp();
            Destroy(gameObject);
        }

    }
}