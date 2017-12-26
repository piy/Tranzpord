using UnityEngine;

public class UIWindowOpener : MonoBehaviour {

    public GameObject Window;
    private GameObject instantiated_window;

    public void OpenWindow()
    {
        if (!instantiated_window)
        {
            instantiated_window = Instantiate(Window);
        }
        else
        {
            if (!instantiated_window.GetComponent<Canvas>().enabled)
            {
                instantiated_window.GetComponent<Canvas>().enabled = true;
            }

            else
            {
                Debug.Log("I am trying to Open " + Window + ", but I can't");
            }
        }
    }

    public void CloseWindow()
    {
        Window.GetComponent<Canvas>().enabled = false;
    }
}
