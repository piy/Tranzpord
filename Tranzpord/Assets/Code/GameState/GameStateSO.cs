using UnityEngine;

[CreateAssetMenu(menuName = "Managers/Game State")]
public class GameStateSO : ScriptableObject
{
    public GameModeSO ActiveGameMode;
    public CitySO ActiveCity;
    public CityRoute ActiveRoute;

    //Initialize
    private void OnEnable()
    {
        SetGameModeTo(GameMode.PlayMode);
        ActiveRoute = null;
    }

    public void SetGameModeTo(GameMode mode)
    {
        ActiveGameMode.CurrentGameMode = mode;
    }
}
