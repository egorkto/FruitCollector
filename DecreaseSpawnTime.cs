using UnityEngine;

public class DecreaseSpawnTime : Upgrade
{
    [SerializeField] private float decreasingSpawnTime;

    public override void ButtonClick(Shop shop)
    {
        shop.ClickButton(this, decreasingSpawnTime);
    }
}
