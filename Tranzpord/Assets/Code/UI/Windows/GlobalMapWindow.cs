public class GlobalMapWindow : UIWindow<GlobalMapWindow>
{
    public override void OnBackBtnPressed()
    {
        base.UIManager.CloseWindow();
    }
}
