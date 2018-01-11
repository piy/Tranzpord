using System;
using System.Collections.Generic;
using UnityEngine;

public class RoutesListWindow : UIWindow<RoutesListWindow>
{
    public GameStateSO game;

    [Header("Route Creation Setup")]
    public GameObject RouteItem;

    Transform ItemsHolder { get { return Instance.gameObject.transform.GetChild(0).transform.Find("ItemsHolder");} }

    List<CityRoute> routeItems = new List<CityRoute>();

    public void Show()
    {
        Open();
        
        if (game.ActiveCity.Routes.Count != Instance.routeItems.Count)
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


    public void CreateRouteItems()
    {
        foreach (var route in game.ActiveCity.Routes)
        {
            CreateRouteItem(route);
        }
    }

    private void CreateRouteItem(CityRoute route)
    {
        GameObject item = Instantiate(RouteItem);
        item.transform.SetParent(ItemsHolder,false);
        item.gameObject.SetActive(true);

        item.GetComponent<RouteItemView>().SetupView(route);

        Instance.routeItems.Add(route);
    }

    private void ShowRoutesOnMap()
    {
        game.ActiveCity.CityClass.ShowRoutes();
    }

    private void HideRoutesOnMap()
    {
        game.ActiveCity.CityClass.HideRoutes();
    }
}
