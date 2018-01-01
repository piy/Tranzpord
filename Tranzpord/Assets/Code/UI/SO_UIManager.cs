using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Managers/UIManager")]
public class SO_UIManager : ScriptableObject {

    public HUDWindow HUD;
    public ExitWindow ExitWindow;
    public GlobalMapWindow GlobalMap;
    public UIWindow RoutesListWindow;

    Stack<UIWindow> windowsStack = new Stack<UIWindow>();

    //Listen To Event BackBtn

    public void OpenWindow<T>() where T : UIWindow
    {
        var prefab = GetPrefab<T>();
        var Instance = Instantiate(prefab);

        //de-activate top windows
        if (windowsStack.Count > 0)
        {
            windowsStack.Peek().gameObject.SetActive(false);   //Make disable canvas
        }

        windowsStack.Push(Instance);
    }


    private T GetPrefab<T>() where T: UIWindow
    {
        if (typeof(T) == typeof(HUDWindow))
            return HUD as T;

        if (typeof(T) == typeof(ExitWindow))
            return ExitWindow as T;

        throw new MissingReferenceException("Trying to get a prefab of: " + typeof(T));
    }

    public void CloseWindow()
    {
        var instance = windowsStack.Pop();
        Destroy(instance);

        //re-activate top window
        if (windowsStack.Count > 0)
        {
            windowsStack.Peek().gameObject.SetActive(true); //canvas
        }
    }

    //On event Back Btn presesd
    void OnBackBtnPressed()
    {
        if (windowsStack.Count > 0)
        {
            windowsStack.Peek().gameObject.SetActive(false); // each window can have it's own exit state...
        } else
        {
            //Show "Do you realy want to exit window
            //Application.Quit();  Or quit if this is the last window
        }
    }
}
