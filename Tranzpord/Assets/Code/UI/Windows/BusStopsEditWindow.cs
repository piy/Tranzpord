using UnityEngine;
using UnityEngine.UI;

public class BusStopsEditWindow : UIWindow<BusStopsEditWindow>
{
    public BusStopBuilder BSBuilder;

    [Header ("Window Components")]
    public Button PlaceBusStopBtn;
    public Button ExitBtn;
    public GameObject BuildBusStopPanel;

    private void OnEnable()
    {
        PlaceBusStopBtn.onClick.AddListener(HandlePlaceBusStopBtnClick);
    }

    private void OnDisable()
    {
        PlaceBusStopBtn.onClick.RemoveAllListeners();
    }

    public void Show()
    {
        PlaceBusStopBtn.onClick.AddListener(HandlePlaceBusStopBtnClick);
        Open();
        BuildBusStopPanel.SetActive(false);
        ExitBtn.gameObject.SetActive(true);

        GameState.Instance.GameData.SetGameModeTo(GameMode.EditBusStops);
        //Show Bus stops info in the world
    }

    public void Hide()
    {
        GameState.Instance.GameData.SetGameModeTo(GameMode.PlayMode);
        //Hide Bus stops info in the world
        Close();
    }

    public void ShowBuildBusStopPanel()
    {
        BuildBusStopPanel.SetActive(true);
        ExitBtn.gameObject.SetActive(false);
    }

    public void HideBuildBusStopPanel()
    {
        BuildBusStopPanel.SetActive(false);
        ExitBtn.gameObject.SetActive(true);
    }

    public void HandlePlaceBusStopBtnClick()
    {
       BSBuilder.BuildBusStop();
    }

}
