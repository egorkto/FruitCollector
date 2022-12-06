using UnityEngine;
using UnityEngine.UI;

public class UpgradeCostShower : MonoBehaviour
{
    private void OnEnable()
    {
        Upgrade.ShowCost += ShowCost;
    }

    private void OnDisable()
    {
        Upgrade.ShowCost -= ShowCost;
    }

    private void ShowCost(Text text, long cost, bool isMaxLevel)
    {
        if (isMaxLevel)
        {
            text.text = "Max";
            return;
        }
        text.text = ScoreConverter.Convert(cost);
    }
}
