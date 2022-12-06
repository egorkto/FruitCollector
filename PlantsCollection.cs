using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlantsCollection : MonoBehaviour
{
    public event Action<CollectorPlant[]> Reset;
    public event Action<CollectorPlant> Activate;
    public event Action<int, int> ShowDiscoveredCount;
    public event Action FullCollection;

    [SerializeField] private CollectorPlant[] plants;

    private List<CollectorPlant> undiscoveredPlants = new List<CollectorPlant>();

    public void ResetCollection()
    {
        Reset?.Invoke(plants);
    }

    private void Awake()
    {
        undiscoveredPlants = plants.ToList();    
    }

    private void OnEnable()
    {
        Spawner.PlantSpawned += CheckPlant;
        LoadEventsHolder.UpdateCollectionData += UpdateData;
        WorldDataConstructor.SetData += GiveData;
    }

    private void OnDisable()
    {
        Spawner.PlantSpawned -= CheckPlant;
        LoadEventsHolder.UpdateCollectionData -= UpdateData;
        WorldDataConstructor.SetData -= GiveData;
    }

    private void CheckPlant(Plant plant)
    {
        foreach(var collectorPlant in undiscoveredPlants)
        {
            if(collectorPlant == plant)
            {
                ActivatePlant(collectorPlant);
                CheckFullCollection();
                break;
            }
        }
    }

    private void ActivatePlant(CollectorPlant plant)
    {
        undiscoveredPlants.Remove(plant);
        Activate?.Invoke(plant);
        ShowDiscoveredCount?.Invoke(plants.Length - undiscoveredPlants.Count, plants.Length);
    }

    private void CheckFullCollection()
    {
        if(plants.Length - undiscoveredPlants.Count == plants.Length)
            FullCollection?.Invoke();
    }

    private void UpdateData(List<CollectorPlantData> data)
    {
        for (var i = 0; i < plants.Length; i++)
            plants[i].SetData(data[i]);
    }

    private void GiveData()
    {
        var data = new List<CollectorPlantData>();
        foreach(var plant in plants)
            data.Add(plant.GetData());
        WorldDataConstructor.Data.CollectionData = data;
    }
}
