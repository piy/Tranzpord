using UnityEngine;

[CreateAssetMenu(menuName = "Managers/SceneManager")]
public class SO_SceneManager : ScriptableObject
{
    public IntVariable ActiveCity;

    public void LoadCity (int cityIndex)
    {
        if (cityIndex == ActiveCity.Value)
        {
            Debug.Log("Close Window, because this is Active City");
        }
        else
        {
            CoreSceneController.SwitchScene(cityIndex);
        }
    }
}

