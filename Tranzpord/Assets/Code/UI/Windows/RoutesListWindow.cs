using UnityEngine;

public class RoutesListWindow : UIWindow<RoutesListWindow>
{
    public GameStateSO game;

    [Header("Route Creation Setup")]
    public GameObject RouteItem;

    Transform ItemsHolder { get { return Instance.gameObject.transform.GetChild(0).transform.Find("ItemsHolder");} }

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
        GameObject item = Instantiate(RouteItem);
        item.transform.SetParent(ItemsHolder,false);
        item.gameObject.SetActive(true);
    }
}
