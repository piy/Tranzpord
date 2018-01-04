using UnityEngine;

public class ExitWindow : SimpleWindow<ExitWindow> {

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
