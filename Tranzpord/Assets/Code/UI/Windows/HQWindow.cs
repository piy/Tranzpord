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
