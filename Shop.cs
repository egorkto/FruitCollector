using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GardensActivator gardensActivator;
    [SerializeField] private ConfigsInitializer configsInitializer;
    [SerializeField] private Upgrade[] upgrades;

    public void ClickButton(DecreaseSpawnTime upgrade, float value)
    {
        if (TryBuy(upgrade))
            configsInitializer.SpawnTimerConfig.DecreaseSpawnTime(value);
    }

    public void ClickButton(IncreaseFreePlaces upgrade, int value)
    {
        if (TryBuy(upgrade))
            configsInitializer.GardenConfig.IncreaseCountFreePlaces(value);
    }

    public void ClickButton(IncreaseProfit upgrade, float value)
    {
        if (TryBuy(upgrade))
            player.IncreaseProfitIndex(value);
    }

    public void ClickButton(AddGarden upgrade)
    {
        if (TryBuy(upgrade))
            gardensActivator.TryActivateNextGarden();
    }

    private bool TryBuy(Upgrade upgrade)
    {
        if(player.CanBuy(upgrade.Cost) && upgrade.CanLevelUp())
        {
            player.TryBuy(upgrade.Cost);
            upgrade.TryLevelUp();
            return true;
        }
        return false;
    }

    private void OnEnable()
    {
        LoadEventsHolder.UpdateShopData += UpdateData;
        WorldDataConstructor.SetData += GiveData;
    }

    private void OnDisable()
    {
        LoadEventsHolder.UpdateShopData -= UpdateData;
        WorldDataConstructor.SetData -= GiveData;
    }

    public void GiveData()
    {
        var result = new List<UpgradeData>();
        foreach (var button in upgrades)
        {
            var data = new UpgradeData()
            {
                Cost = button.Cost,
                Level = button.Level
            };
            result.Add(data);
        }
        WorldDataConstructor.Data.ShopData = result;
    }

    public void UpdateData(List<UpgradeData> data)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            upgrades[i].SetCost(data[i].Cost);
            upgrades[i].SetLevel(data[i].Level);
        }
    }
}