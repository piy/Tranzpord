using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(menuName = "Managers/UIManager")]
public class SO_UIManager : ScriptableObject {

    public HUDWindow HUD;
    public ExitWindow ExitWindow;
    public GlobalMapWindow GlobalMap;
    public UIWindow RoutesListWindow;

    Stack<UIWindow> uiStack = new Stack<UIWindow>();

    public void OpenWindow<T>() where T : UIWindow
    {
        var prefab = GetPrefab<T>();
        var Instance = Instantiate(prefab);
                        //create ref to GameObject in class
                        //this is needed just to check if the window is already created. Or just disabled Canvas. Maybe I could find neat workaround
                        //Instance.gameObject.GetComponent<UIWindow<T>>().SetInstance(Instance);

        //De-activate top windows
        if (uiStack.Count > 0)
        {
            if (Instance.DisableWindowsUnder)
            {
                foreach(var window in uiStack)
                {
                    window.GetComponent<Canvas>().enabled = false;
                    //window.gameObject.SetActive(false);

                    if (window.DisableWindowsUnder)
                        break;
                }
            }

            var TopCanvas = Instance.GetComponent<Canvas>();
            var PreviousCanvas = uiStack.Peek().GetComponent<Canvas>();
            TopCanvas.sortingOrder = PreviousCanvas.sortingOrder + 1;
        }

        uiStack.Push(Instance);
       
    }

    
    private T GetPrefab<T>() where T : UIWindow
    {
        // Get prefab dynamically, based on public fields set from Unity

        var fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        foreach (var field in fields)
        {
            var prefab = field.GetValue(this) as T;
            if (prefab != null)
            {
                return prefab;
            }
        }

        throw new MissingReferenceException("Prefab not found for type: " + typeof(T));

        //if (typeof(T) == typeof(HUDWindow))
        //    return HUD as T;

        //if (typeof(T) == typeof(ExitWindow))
        //    return ExitWindow as T;

        //throw new MissingReferenceException("Trying to get a prefab of: " + typeof(T));
    }

    public void CloseWindow(UIWindow window)
    {
        if (uiStack.Count == 0)
        {
            Debug.LogErrorFormat(window, "{0} cannot be closed because UI stack is empty", window.GetType());
            return;
        }

        if (uiStack.Peek() != window)
        {
            Debug.LogErrorFormat(window, "{0} cannot be closed because it is not on the top of the Stack", window.GetType());
            return;
        }

        CloseTopWindow();
    }

    public void CloseTopWindow()
    {
        var instance = uiStack.Pop();

        if (instance.DestroyWhenClosed)
            Destroy(instance);
        else
            instance.GetComponent<Canvas>().enabled = false;


        //re-activate top window
        //If a re-activated window is an overlay we need to activate the window under it
        foreach (var win in uiStack)
        {
            win.GetComponent<Canvas>().enabled = true;

            if (win.DisableWindowsUnder)
                break;
        }

    }

    public void OnBackBtnPressed()
    {
        if (uiStack.Count > 0)
        {
            uiStack.Peek().OnBackBtnPressed(); // each window can have it's own exit state...
        }
    }
}
