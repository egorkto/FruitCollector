using System;
using System.Collections.Generic;

public static class LoadEventsHolder
{
    public static event Action<PlayerData> UpdatePlayerData;
    public static event Action<ConfigsData> UpdateConfigsData;
    public static event Action<List<CollectorPlantData>> UpdateCollectionData;
    public static event Action<List<UpgradeData>> UpdateShopData;
    public static event Action<List<GardenData>> UpdateGadensData;

    public static void UpdateData(WorldData data)
    {
        UpdatePlayerData?.Invoke(data.PlayerData);
        UpdateConfigsData?.Invoke(data.ConfigsData);
        UpdateCollectionData?.Invoke(data.CollectionData);
        UpdateShopData?.Invoke(data.ShopData);
        UpdateGadensData?.Invoke(data.GardensData);
    }
}
