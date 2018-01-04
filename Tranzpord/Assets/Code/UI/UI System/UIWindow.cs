using UnityEngine;

public abstract class UIWindow<T> : UIWindow where T : UIWindow<T>
{
    public static T Instance { get; private set; }
    public SO_UIManager UIManager;

    protected virtual void Awake()
    {
        //Debug.Log(name + " .My instance is set to be: " + Instance);
        Instance = (T)this;
    }

    protected virtual void OnDestroy()
    {
        Instance = null;
    }

    protected void Open()
    {
        //Debug.Log("Open: " + name + ". And my instance is: " + Instance);

        if (Instance == null)
            UIManager.CreateWindow<T>();
        else
            Instance.GetComponent<Canvas>().enabled = true;

        UIManager.OpenWindow(Instance);
    }

    protected void Close()
    {
        if (Instance == null)
        {
            Debug.LogErrorFormat("Trying to close menu {0} but Instance is null", typeof(T));
            return;
        }

        UIManager.CloseWindow(Instance);
    }

    public override void OnBackBtnPressed()
    {
        Close();
    }

}



public abstract class UIWindow : MonoBehaviour {

    [Tooltip("Destroy GameObject, or just disable Canvas")]
    public bool DestroyWhenClosed = false;

    [Tooltip("Disable Windows under this one?")]
    public bool DisableWindowsUnder = true;

    public abstract void OnBackBtnPressed();
}


//public class ComplexWindow : UIWindow<ComplexWindow>
//{
//    public void Show(string foo)
//    {
//        Open();
//        //foo code here
//    }

//    public void Hide(int result)
//    {
//        //result code goes here
//        Close();
//    }
//}