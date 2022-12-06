using System;
using System.Collections.Generic;
using UnityEngine;

public class GardensActivator : MonoBehaviour
{
    public event Action<Garden> GardenActivated;

    [SerializeField] private List<Garden> gardens;

    private List<Garden> activeGardens = new List<Garden>();
    private int nextGardenIndex = 0;

    public void TryActivateNextGarden()
    {
        if(nextGardenIndex >= gardens.Count)
            Debug.LogError("Доступные огороды закончились!");
        gardens[nextGardenIndex].Activate();
        activeGardens.Add(gardens[nextGardenIndex]);
        GardenActivated?.Invoke(gardens[nextGardenIndex]);
        nextGardenIndex++;
    }

    private void OnEnable()
    {
        LoadEventsHolder.UpdateGadensData += UpdateData;
        WorldDataConstructor.SetData += GiveData;
    }

    private void OnDisable()
    {
        LoadEventsHolder.UpdateGadensData -= UpdateData;
        WorldDataConstructor.SetData -= GiveData;
    }

    public void GiveData()
    {
        var result = new List<GardenData>();
        foreach (var garden in activeGardens)
            result.Add(new GardenData() { PlantsDataList = garden.GetData() });
        WorldDataConstructor.Data.GardensData = result;
    }

    public void UpdateData(List<GardenData> data)
    {
        for (var i = 0; i < data.Count; i++)
        {
            TryActivateNextGarden();
            activeGardens[i].SetPlants(data[i].PlantsDataList);
        }
    }
}
