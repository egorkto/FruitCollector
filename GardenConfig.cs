using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "GardenConfig", menuName = "GardenConfig", order = 0)]
public class GardenConfig : ScriptableObject
{
    public int CountFreePlaces => countFreePlaces;

    [SerializeField] private int countFreePlaces;

    public void IncreaseCountFreePlaces(int value)
    {
        countFreePlaces += value;
    }

    public void SetCountFreePlaces(int value)
    {
        countFreePlaces = value;
    }
}
