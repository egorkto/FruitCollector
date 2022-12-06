using UnityEngine;
using UnityEngine.UI;

public class GardenPlacesShower : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private ToCameraMover cameraMover;

    private Garden currentGarden;

    private void OnEnable()
    {
        cameraMover.ChangedActiveGarden += TryChangeGarden;
    }

    private void OnDisable()
    {
        cameraMover.ChangedActiveGarden -= TryChangeGarden;
        TryUnsubscribe();  
    }

    private void TryChangeGarden(Garden garden)
    {
        if (currentGarden != garden)
        {
            TryUnsubscribe();
            ChangeGarden(garden);
        }
    }

    private void TryUnsubscribe()
    {
        if (currentGarden != null)
            currentGarden.ShowPlaces -= ShowGardenPlaces;
    }

    private void ChangeGarden(Garden garden)
    {
        currentGarden = garden;
        ShowGardenPlaces(currentGarden);
        currentGarden.ShowPlaces += ShowGardenPlaces;
    }

    private void ShowGardenPlaces(Garden garden)
    {
        text.text = garden.CountOccupiedPlaces + "/" + garden.CountFreePlaces;
    }
}
