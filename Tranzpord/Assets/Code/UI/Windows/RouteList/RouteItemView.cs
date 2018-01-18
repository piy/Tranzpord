using UnityEngine;
using UnityEngine.UI;

public class RouteItemView : MonoBehaviour {

    private CityRouteSO myRoute;
    public SO_UIManager UIManager;

    public Text RouteName;
    public Text RouteLenght;
    public Button EditBtn;


    private void OnEnable()
    {
        EditBtn.onClick.AddListener(HandleEditBtnClick);
    }

    private void OnDisable()
    {
        EditBtn.onClick.RemoveAllListeners();
    }


    public void SetupView(CityRouteSO route)
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

    public void HandleEditBtnClick()
    {
        GameState.Instance.GameData.ActiveRoute = myRoute;
        OpenEditRouteUI();
    }

    public void OpenEditRouteUI()
    {
        UIManager.RouteEdit.Show();
    }
}
