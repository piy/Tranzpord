using UnityEngine;

public class RoutesListWindow : SimpleWindow<RoutesListWindow>
{
    public GameStateSO game;

    public void OpenEditRouteUI()
    {
        //UIManager.RouteEdit.Show();
        Test();
    }

    public void Test()
    {
        foreach (var route in game.ActiveCity.myRoutes)
        {
            if (route.isUnlocked)
            {
                Debug.Log(route + "route is!");
            }
        }
    }
}
