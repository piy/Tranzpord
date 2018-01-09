public class RouteEditWindow : UIWindow<RouteEditWindow>
{
    public GameStateSO game;

    public void Show()
    {
        Open();
        game.SetGameModeTo(GameMode.EditRoute);
        game.ActiveRoute = game.ActiveCity.Routes[0];         //HACK! Should be set by UI
    }

    public void Hide()
    {
        game.SetGameModeTo(GameMode.PlayMode);
        game.ActiveRoute = null;
        Close();
    }
}
