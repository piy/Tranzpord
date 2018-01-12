using UnityEngine;

public class BusShopWindow : UIWindow<BusShopWindow>
{
    public void Show()
    {
        Open();
    }


    public void Hide()
    {
        Close();
    }


    public void BuyBusBtn()
    {
        Debug.Log("You have a bus now!");
    }
}
