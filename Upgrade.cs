using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public abstract class Upgrade : MonoBehaviour
{
    public static event Action<Text, long, bool> ShowCost;

    public long Cost => cost;
    public int Level => level;

    [SerializeField] private long cost;
    [SerializeField] private Text costText;
    [SerializeField] private int costIncreasing;
    [SerializeField] private int maxLevel;

    private int level = 1;

    public void SetCost(long value)
    {
        if (value >= 0)
            cost = value;
    }

    public void SetLevel(int value)
    {
        if (value >= 0)
            level = value;
    }

    public abstract void ButtonClick(Shop shop);

    public void TryLevelUp()
    {
        if(CanLevelUp())
        {
            IncreaseProperties();
            ShowCost?.Invoke(costText, cost, level >= maxLevel);
        }
    }

    public bool CanLevelUp()
    {
        if (level < maxLevel)
            return true;
        return false;
    }

    private void Start()
    {
        ShowCost?.Invoke(costText, cost, level >= maxLevel);
    }

    private void IncreaseProperties()
    {
        level += 1;
        cost *= costIncreasing;
    }
}
