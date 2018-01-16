using UnityEngine.UI;

public class RouteEditWindow : UIWindow<RouteEditWindow>
{
    public GameStateSO game;
    public BusSpawner BusSpawner;
    public Button AddBusBtn;

    private void OnEnable()
    {
        AddBusBtn.onClick.AddListener(HandleAddBusBtnClick);
    }

    private void OnDisable()
    {
        AddBusBtn.onClick.RemoveAllListeners();
    }

    public void Show()
    {
        AddBusBtn.onClick.AddListener(HandleAddBusBtnClick);
        Open();
        game.SetGameModeTo(GameMode.EditRoute);
    }

    public void Hide()
    {
        game.SetGameModeTo(GameMode.PlayMode);
        game.ActiveRoute = null;
        Close();
    }

    public void HandleAddBusBtnClick()
    {
        BusSpawner.SpawnBus(game.ActiveRoute);
    }
}
