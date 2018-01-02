public class HUDWindow : SimpleWindow<HUDWindow>
{
    public override void OnBackBtnPressed()
    {
        base.UIManager.OpenWindow<ExitWindow>();
    }

    public void OpenGlobalMap()
    {
        UIManager.OpenWindow<GlobalMapWindow>();
    }

    public void OpenRouteList()
    {
        UIManager.OpenWindow<RoutesListWindow>();
    }
}
