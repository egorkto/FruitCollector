using System;
using UnityEngine;

[Serializable]
public class Player : MonoBehaviour
{
    public event Action<long> ShowScore;
    public event Action<long> ShowProfit;

    private long score = 0;
    private long profit = 0;
    private float profitIndex = 1;
    private GivingMoneyTimer timer = new GivingMoneyTimer();

    public void IncreaseProfit(long value)
    {
        profit += (long)((double)value * profitIndex);
        ShowProfit?.Invoke(profit);
    }

    public void TryDecreaseProfit(long value)
    {
        if(profit >= value)
        {
            profit -= (long)((double)value * profitIndex);
            ShowProfit?.Invoke(profit);
        }
    }

    public void IncreaseProfitIndex(float value)
    {
        profitIndex += value;
        profit = (long)((double)profit * (1.0f + value));
        ShowProfit?.Invoke(profit);
    }

    public bool CanBuy(long cost)
    {
        return score >= cost;
    }

    public void TryBuy(long cost)
    {
        if(CanBuy(cost))
        {
            score -= cost;
            ShowScore?.Invoke(score);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(timer.StartTimer());
        timer.TimeUp += GetMoney;
        WorldDataConstructor.SetData += GiveData;
        LoadEventsHolder.UpdatePlayerData += UpdateData;
    }

    private void OnDisable()
    {
        timer.TimeUp -= GetMoney;
        WorldDataConstructor.SetData -= GiveData;
        LoadEventsHolder.UpdatePlayerData -= UpdateData;
    }

    private void GetMoney()
    {
        score += profit;
        ShowScore?.Invoke(score);
    }

    private void GiveData()
    {
        WorldDataConstructor.Data.PlayerData = new PlayerData()
        {
            Score = score,
            ProfitIndex = profitIndex
        };
    }

    private void UpdateData(PlayerData data)
    {
        score = data.Score;
        profitIndex = data.ProfitIndex;
    }
}
