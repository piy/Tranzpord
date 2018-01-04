public class HUDWindow : SimpleWindow<HUDWindow>
{
    public override void OnBackBtnPressed()
    {
        UIManager.ExitWindow.Show();
    }

    public void OpenGlobalMap()
    {
        //UIManager.OpenWindow<GlobalMapWindow>();
        UIManager.GlobalMap.Show();
    }

    public void OpenRouteList()
    {
        UIManager.RoutesListWindow.Show();
    }
}
