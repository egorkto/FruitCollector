using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "SpawnTimerConfig", menuName = "SpawnTimerConfig", order = 0)]
public class SpawnTimerConfig : ScriptableObject
{
    public float SpawnTime => spawnTime;
    public float ReduceTimeOfClick => reduceTimeOfClick;

    [SerializeField] private float spawnTime;
    [SerializeField] private float reduceTimeOfClick;

    public void DecreaseSpawnTime(float value)
    {
        if(spawnTime > value)
        {
            spawnTime -= value;
        }
    }

    public void SetSpawnTime(float value)
    {
        spawnTime = value;
    }
}
