using UnityEngine;

public class HUDInitializer : MonoBehaviour {

    public SO_UIManager UIManager;

    private void Awake()
    {
        //Check if it is already available
        UIManager.HUD.Show();
    }
}
