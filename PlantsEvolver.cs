using System;
using UnityEngine;

public class PlantsEvolver : MonoBehaviour
{
    public event Action<Plant, Vector2> SpawnEvolvedPlant;

    [SerializeField] private Plant[] plants;

    public Plant GetLowestTierPlant()
    {
        return plants[0];
    }

    public Plant GetPlant(Sprite sprite)
    {
        var index = IndexOf(sprite);
        if(index == -1)
            Debug.LogError($"Не существует растения со спрайтом {sprite}");
        return plants[index];
    }

    public bool TryEvolve(Plant evolvedPlant, Plant joinedPlant)
    {
        var index = IndexOf(evolvedPlant.Sprite);
        if (index != -1 && TryGetNextPlant(index, out Plant nextPlant))
        {
            evolvedPlant.Destroy();
            joinedPlant.Destroy();
            SpawnEvolvedPlant?.Invoke(nextPlant, evolvedPlant.transform.position);
            return true;
        }
        return false;
    }

    private bool TryGetNextPlant(int index, out Plant outPlant)
    {
        var success = index < plants.Length - 1;
        outPlant = success ? plants[index + 1] : null;
        return success;
    }

    private int IndexOf(Sprite sprite)
    {
        foreach (var plant in plants)
            if (sprite == plant.Sprite)
                return Array.IndexOf(plants, plant);
        return -1;
    }
}
