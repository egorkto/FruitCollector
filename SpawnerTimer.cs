using System;
using UnityEngine;

public class SpawnerTimer : MonoBehaviour
{
    public event Action<float, float> ProgressChanged;
    public event Action TimeUp;

    [SerializeField] private SpawnTimerConfig config;
    [SerializeField] private ClickButton button;

    private float timeBetweenSpawn;

    private void OnEnable()
    {
        button.Click += ReduceSpawnTime;
    }

    private void OnDisable()
    {
        button.Click -= ReduceSpawnTime;
    }

    private void ReduceSpawnTime()
    {
        timeBetweenSpawn += config.ReduceTimeOfClick;
    }

    private void FixedUpdate()
    {
        SpawnerTick();
        ProgressChanged?.Invoke(timeBetweenSpawn, config.SpawnTime);
    }

    private void SpawnerTick()
    {
        if (timeBetweenSpawn >= config.SpawnTime)
        {
            TimeUp?.Invoke();
            timeBetweenSpawn = 0;
        }
        else
            timeBetweenSpawn += Time.deltaTime;
    }
}
