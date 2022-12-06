using UnityEngine;

public class PlayerProfitCalculator : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnEnable()
    {
        Spawner.PlantSpawned += AddPlant;
    }

    private void OnDisable()
    {
        Spawner.PlantSpawned -= AddPlant;
    }

    private void AddPlant(Plant plant)
    {
        player.IncreaseProfit(plant.Cost);
        plant.Destroyed += RemovePlant;
    }

    private void RemovePlant(Plant plant)
    {
        player.TryDecreaseProfit(plant.Cost);
        plant.Destroyed -= RemovePlant;
    }
}
