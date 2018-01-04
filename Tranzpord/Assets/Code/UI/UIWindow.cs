using UnityEngine;

public abstract class UIWindow<T> : UIWindow where T : UIWindow<T>
{
    public T Instance { get; private set; }
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
        if (Instance != null)
            Instance.GetComponent<Canvas>().enabled = true;   
        else
            UIManager.OpenWindow<T>();
    }

    protected void Close()
    {
        //If window is null -> catch error

        UIManager.CloseWindow(this);
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



public abstract class SimpleWindow<T> : UIWindow<T> where T : SimpleWindow<T>
{
    public void Show()
    {
        Open();
    }

    public void Hide()
    {
        Close();
    }
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