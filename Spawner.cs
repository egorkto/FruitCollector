using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static event Action<Plant> PlantSpawned;

    [SerializeField] private PlantsEvolver evolver;
    [SerializeField] private SpawnerTimer spawnTimer;

    private Garden garden;
    private Plant lowestTierPlant;

    public void StartSpawn(Garden _garden)
    {
        garden = _garden;
        lowestTierPlant = evolver.GetLowestTierPlant();
        spawnTimer.TimeUp += SpawnByTimer;
        evolver.SpawnEvolvedPlant += Spawn;
    }

    public void StopSpawn()
    {
        spawnTimer.TimeUp -= SpawnByTimer;
        evolver.SpawnEvolvedPlant -= Spawn;
    }

    public void SpawnPlants(List<PlantData> plantsData)
    {
        foreach(var data in plantsData)
            Spawn(evolver.GetPlant(data.Sprite), data.Position);
    } 

    private void Spawn(Plant plant, Vector2 position)
    {
        var currentPlant = Instantiate(plant, new Vector3(position.x, position.y, 0), Quaternion.identity);
        garden.AddPlant(currentPlant);
        currentPlant.transform.SetParent(garden.transform);
        PlantSpawned?.Invoke(currentPlant);
    }

    private void SpawnByTimer()
    {
        if (garden.HaveFreePlaces())
            Spawn(lowestTierPlant, garden.Calculator.GetRandomSpawnPoint());
    }
}