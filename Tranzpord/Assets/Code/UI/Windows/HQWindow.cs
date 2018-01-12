using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQWindow : UIWindow<HQWindow>
{
    public void Show()
    {
        Open();
    }


    public void Hide()
    {
        Close();
    }



    public void OpenBusShopWindow()
    {
        UIManager.BusShop.Show();
    }
}
