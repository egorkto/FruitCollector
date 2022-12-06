using UnityEngine;
using UnityEngine.UI;

public class SpawnPlantProgressShower : MonoBehaviour
{
    [SerializeField] private SpawnerTimer timer;
    [SerializeField] private Image progressImage;

    private void OnEnable()
    {
        timer.ProgressChanged += ShowProgress;
    }
    private void OnDisable()
    {
        timer.ProgressChanged -= ShowProgress;
    }

    private void ShowProgress(float currentTime, float maxTime)
    {
        var filling = currentTime / maxTime;
        progressImage.fillAmount = filling;
    }
}   
