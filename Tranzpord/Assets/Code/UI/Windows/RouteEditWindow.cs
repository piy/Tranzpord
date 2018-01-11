public class RouteEditWindow : UIWindow<RouteEditWindow>
{
    public GameStateSO game;

    public void Show()
    {
        Open();
        game.SetGameModeTo(GameMode.EditRoute);
    }

    public void Hide()
    {
        game.SetGameModeTo(GameMode.PlayMode);
        game.ActiveRoute = null;
        Close();
    }
}
