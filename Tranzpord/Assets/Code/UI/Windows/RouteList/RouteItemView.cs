using UnityEngine;
using UnityEngine.UI;

public class RouteItemView : MonoBehaviour {

    private CityRoute myRoute;
    public GameStateSO Game;
    public SO_UIManager UIManager;

    public Text RouteName;
    public Text RouteLenght;
    public Button EditBtn;

    public void SetupView(CityRoute route)
    {
        myRoute = route;

        if (myRoute.isUnlocked)
        {
            RouteName.text = myRoute.RouteName;
            RouteLenght.text = myRoute.RouteTiles.Count.ToString();
        }
        else
        {
            RouteName.text = "Locked";
            RouteLenght.text = null;
            EditBtn.gameObject.SetActive(false);
        }

        RouteName.color += myRoute.GetColor();
    }

    public void OpenEditRouteUI()
    {
        Game.ActiveRoute = myRoute;
        UIManager.RouteEdit.Show();
    }
}
