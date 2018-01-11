using UnityEngine;
using UnityEngine.UI;

public class RouteItemView : MonoBehaviour {

    private CityRouteSO myRoute;
    public GameStateSO Game;
    public SO_UIManager UIManager;

    public Text RouteName;
    public Text RouteLenght;
    public Button EditBtn;

    public void SetupView(CityRouteSO route)
    {
        myRoute = route;
        EditBtn.onClick.AddListener(HandleEditBtnClick);

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

    public void HandleEditBtnClick()
    {
        Game.ActiveRoute = myRoute;
        OpenEditRouteUI();
    }

    public void OpenEditRouteUI()
    {
        UIManager.RouteEdit.Show();
    }
}
