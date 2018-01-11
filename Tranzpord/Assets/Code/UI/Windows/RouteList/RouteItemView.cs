using UnityEngine;
using UnityEngine.UI;

public class RouteItemView : MonoBehaviour {

    public Text RouteName;
    public Text RouteLenght;
    public Button EditBtn;

    public void SetupView(Color color, bool unlocked, string Name, int Lenght)
    {
        if (unlocked)
        {
            RouteName.text = Name;
            RouteLenght.text = Lenght.ToString();
        }
        else
        {
            RouteName.text = "Locked";
            RouteLenght.text = null;
            EditBtn.gameObject.SetActive(false);
        }

        RouteName.color += color;
    }
}
