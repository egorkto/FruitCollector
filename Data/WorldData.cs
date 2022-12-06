using System;
using System.Collections.Generic;

[Serializable]
public struct WorldData
{
    public PlayerData PlayerData;
    public ConfigsData ConfigsData;
    public List<CollectorPlantData> CollectionData;
    public List<UpgradeData> ShopData;
    public List<GardenData> GardensData;
}
