using UnityEngine;

public class ConfigsInitializer : MonoBehaviour
{
    public SpawnTimerConfig SpawnTimerConfig => spawnTimerConfig;
    public GardenConfig GardenConfig => gardenConfig;

    [SerializeField] private SpawnTimerConfig spawnTimerConfig;
    [SerializeField] private GardenConfig gardenConfig;

    private void OnEnable()
    {
        LoadEventsHolder.UpdateConfigsData += UpdateData;
        WorldDataConstructor.SetData += GiveData;
    }

    private void OnDisable()
    {
        LoadEventsHolder.UpdateConfigsData -= UpdateData;
        WorldDataConstructor.SetData -= GiveData;
    }

    public void UpdateData(ConfigsData data)
    {
        gardenConfig.SetCountFreePlaces(data.CountPlacesInGarden);
        spawnTimerConfig.SetSpawnTime(data.SpawnTime);
    }

    public void GiveData()
    {
        var data = new ConfigsData() { SpawnTime = spawnTimerConfig.SpawnTime, CountPlacesInGarden = gardenConfig.CountFreePlaces };
        WorldDataConstructor.Data.ConfigsData = data;
    }
}
