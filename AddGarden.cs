public class AddGarden : Upgrade
{
    public override void ButtonClick(Shop shop)
    {
        shop.ClickButton(this);
    }
}
