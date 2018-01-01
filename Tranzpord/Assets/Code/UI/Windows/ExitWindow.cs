using UnityEngine;

public class ExitWindow : UIWindow<ExitWindow> {

    public override void OnBackBtnPressed()
    {
        //Save
        Application.Quit();
    }
}
