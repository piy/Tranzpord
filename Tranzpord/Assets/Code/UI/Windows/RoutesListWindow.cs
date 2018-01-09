using UnityEngine;

public class RoutesListWindow : UIWindow<RoutesListWindow>
{
    public GameStateSO game;

    [Header("Route Creation Setup")]
    [SerializeField]
    GameObject   RouteHolder;
    [SerializeField]
    GameObject RouteItem;

    public void Show()
    {
        Open();
        //Check if items already created -> just show them
        CreateRouteItems();
    }

    public void Hide()
    {
        Close();
    }

    public void OpenEditRouteUI()
    {
        UIManager.RouteEdit.Show();
    }

    public void CreateRouteItems()
    {
        foreach (var route in game.ActiveCity.Routes)
        {
            FillRouteInfo(route);
        }
    }

    private void FillRouteInfo(CityRoute route)
    {
        //var item = Instantiate(RouteItem, RouteHolder.transform);

        //if (!item.activeInHierarchy)
        //{
        //    item.SetActive(true);
        //}

        Debug.Log("Route UI creation should be here");
    }
}
