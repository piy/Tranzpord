public class RoutesListWindow : SimpleWindow<RoutesListWindow>
{
    public void OpenEditRouteUI()
    {
        UIManager.OpenWindow<RouteEditWindow>();
    }
}
