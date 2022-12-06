using UnityEngine;

public class IncreaseProfit : Upgrade
{
    [SerializeField] private float increasingProfit;

    public override void ButtonClick(Shop shop)
    {
        shop.ClickButton(this, increasingProfit);
    }
}
