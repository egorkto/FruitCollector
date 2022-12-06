using UnityEngine;

public class IncreaseFreePlaces : Upgrade
{
    [SerializeField] private int increasingFreePlaces;

    public override void ButtonClick(Shop shop)
    {
        shop.ClickButton(this, increasingFreePlaces);
    }
}
