using UnityEngine.UI;

public class BusStopsEditWindow : UIWindow<BusStopsEditWindow>
{
    public GameStateSO game;
    public BusStopBuilder BSBuilder;
    public Button PlaceBusStopBtn;

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
        game.SetGameModeTo(GameMode.EditBusStops);
    }

    public void Hide()
    {
        game.SetGameModeTo(GameMode.PlayMode);
        //game.ActiveRoute = null;
        Close();
    }

    public void HandlePlaceBusStopBtnClick()
    {
        BSBuilder.BuildBusStop();           //temporary
    }

}
