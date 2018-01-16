using UnityEngine;

public class ExitWindow : SimpleWindow<ExitWindow> {

    public override void OnBackBtnPressed()
    {
        Hide();
    }

    public void ExitGame()
    {
        //Save
        UIManager.ExitWindow.Hide();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
