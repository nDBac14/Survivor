using UnityEngine;

public class PassiveUpgrade : IUpgrade
{
    private readonly PassiveManager manager;
    private readonly PassiveData data;

    public PassiveUpgrade(PassiveManager manager, PassiveData data)
    {
        this.manager = manager;
        this.data = data;
    }

    public string Title => (manager.Has(data) ? "Nâng: " : "Mới: ") + data.passiveName;
    public string Description => "+" + Mathf.RoundToInt(data.amountPerLevel * 100) +
                                "% (cấp " + (manager.LevelOf(data) + 1) + ")";

    public void Apply() => manager.AddOrLevel(data);
}