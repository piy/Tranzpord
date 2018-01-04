using UnityEngine;

public class HUDInitializer : MonoBehaviour {

    public SO_UIManager UIManager;

    private void Awake()
    {
        UIManager.ClearUp();
    }

    private void Start()
    {
        //Check if it is already available
        UIManager.HUD.Show();
    }
}
