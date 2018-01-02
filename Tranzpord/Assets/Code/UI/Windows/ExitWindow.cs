using UnityEngine;

public class ExitWindow : UIWindow<ExitWindow> {

    public override void OnBackBtnPressed()
    {
        ExitGame();
    }

    public void ExitGame()
    {
        //Save
        UIManager.CloseWindow(this);
        Application.Quit();
    }
}
