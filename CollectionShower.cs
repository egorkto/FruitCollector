using UnityEngine;
using UnityEngine.UI;

public class CollectionShower : MonoBehaviour
{
    [SerializeField] private PlantsCollection collection;
    [SerializeField] private Text discoveryInformation;

    private void OnEnable()
    {
        collection.Reset += ResetCollection;
        collection.Activate += Activate;
        collection.ShowDiscoveredCount += ShowDiscoveredCount;
        collection.FullCollection += SetCongratulationText;
    }

    private void OnDisable()
    {
        collection.Reset -= ResetCollection;
        collection.Activate -= Activate;
        collection.ShowDiscoveredCount -= ShowDiscoveredCount;
        collection.FullCollection -= SetCongratulationText;
    }

    private void ResetCollection(CollectorPlant[] plants)
    {
        foreach (var plant in plants)
            plant.SetColor(new Color(0.1f, 0.1f, 0.1f));
    }

    private void Activate(CollectorPlant plant)
    {
        plant.SetColor(new Color(1, 1, 1));
    }

    private void ShowDiscoveredCount(int discovered, int count)
    {
        discoveryInformation.text = $"{discovered}/{count} Collected";
    }

    private void SetCongratulationText()
    {
        discoveryInformation.text = $"You have collected all the plants!";
    }
}
