using System;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    public event Action<Garden> ShowPlaces;
    
    public int CountOccupiedPlaces => countOccupiedPlaces;
    public int CountFreePlaces => config.CountFreePlaces;
    public ScaleCalculator Calculator => calculator;

    [SerializeField] private ScaleCalculator calculator;
    [SerializeField] private GardenConfig config;
    [SerializeField] private Spawner spawner;

    private int countOccupiedPlaces = 0;
    private List<Plant> plants = new List<Plant>();

    public void Activate()
    {
        spawner.StartSpawn(this);
    }

    public void Disactivate()
    {
        spawner.StopSpawn();
    }

    public bool HaveFreePlaces()
    {
        return config.CountFreePlaces > countOccupiedPlaces;
    }

    public void AddPlant(Plant plant)
    {
        OccupiedPlace(plant);
        plant.Destroyed += FreePlace;
    }

    public List<PlantData> GetData()
    {
        var result = new List<PlantData>();
        foreach(var plant in plants)
            result.Add(new PlantData() { Sprite = plant.Sprite, Position = plant.transform.position });
        return result;
    }

    public void SetPlants(List<PlantData> data)
    {
        spawner.SpawnPlants(data);
    }

    private void OccupiedPlace(Plant plant)
    {
        countOccupiedPlaces += 1;
        ShowPlaces?.Invoke(this);
        plants.Add(plant);
    }

    private void FreePlace(Plant plant)
    {
        countOccupiedPlaces -= 1;
        ShowPlaces?.Invoke(this);
        plants.Remove(plant);
        plant.Destroyed -= FreePlace;
    }
}
