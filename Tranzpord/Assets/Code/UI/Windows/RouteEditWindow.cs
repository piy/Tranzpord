using UnityEngine.UI;

public class RouteEditWindow : UIWindow<RouteEditWindow>
{
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
        GameState.Instance.GameData.SetGameModeTo(GameMode.EditRoute);
    }

    public void Hide()
    {
        GameState.Instance.GameData.SetGameModeTo(GameMode.PlayMode);
        GameState.Instance.GameData.ActiveRoute = null;
        Close();
    }

    public void HandleAddBusBtnClick()
    {
        BusSpawner.SpawnBus(GameState.Instance.GameData.ActiveRoute);
    }
}
