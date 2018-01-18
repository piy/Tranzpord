using System;
using System.Collections.Generic;
using UnityEngine;

public class RoutesListWindow : UIWindow<RoutesListWindow>
{
    [Header("Route Creation Setup")]
    public GameObject RouteItem;

    Transform ItemsHolder { get { return Instance.gameObject.transform.GetChild(0).transform.Find("ItemsHolder");} }

    List<CityRouteSO> routeItems = new List<CityRouteSO>();

    public void Show()
    {
        Open();
        
        if (GameState.Instance.GameData.ActiveCity.Routes.Count != Instance.routeItems.Count)
        {
            routeItems.Clear();
            CreateRouteItems();
        }

        ShowRoutesOnMap();
    }


    public void Hide()
    {
        HideRoutesOnMap();
        Close();
    }


    public override void OnBackBtnPressed()
    {
        Hide();
    }


    public void CreateRouteItems()
    {
        foreach (var route in GameState.Instance.GameData.ActiveCity.Routes)
        {
            CreateRouteItem(route);
        }
    }

    private void CreateRouteItem(CityRouteSO route)
    {
        GameObject item = Instantiate(RouteItem);
        item.transform.SetParent(ItemsHolder,false);
        item.gameObject.SetActive(true);

        item.GetComponent<RouteItemView>().SetupView(route);

        Instance.routeItems.Add(route);
    }

    private void ShowRoutesOnMap()
    {
        GameState.Instance.GameData.ActiveCity.CityClass.ShowRoutes();
    }

    private void HideRoutesOnMap()
    {
        GameState.Instance.GameData.ActiveCity.CityClass.HideRoutes();
    }
}
