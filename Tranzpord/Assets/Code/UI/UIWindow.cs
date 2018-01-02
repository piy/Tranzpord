using UnityEngine;

public abstract class UIWindow<T> : UIWindow where T : UIWindow<T>
{
    private GameObject instance;
    public SO_UIManager UIManager;

    protected void Open()
    {

        if (instance == null)
            UIManager.OpenWindow<T>();
        else
            instance.GetComponent<Canvas>().enabled = true;   
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

    public void SetInstance(GameObject go)
    {
        instance = go;
    }
}



public abstract class UIWindow : MonoBehaviour{

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



public class ComplexWindow : UIWindow<ComplexWindow>
{
    public void Show(string foo)
    {
        Open();
        //foo code here
    }

    public void Hide(int result)
    {
        //result code goes here
        Close();
    }
}