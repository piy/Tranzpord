using UnityEngine;

public abstract class UIWindow<T> : UIWindow where T : UIWindow<T>
{
    public SO_UIManager UIManager;
}

public abstract class UIWindow : MonoBehaviour{

    public abstract void OnBackBtnPressed();
}

