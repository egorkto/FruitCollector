using System;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTimerShower : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private SpawnerTimer timer;

    private void OnEnable()
    {
        timer.ProgressChanged += ShowTime;
    }

    private void OnDisable()
    {
        timer.ProgressChanged -= ShowTime;
    }

    private void ShowTime(float currentTime, float maxTime)
    {
        text.text = Math.Round(maxTime - currentTime, 1).ToString();
    }
}
