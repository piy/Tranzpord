using UnityEngine;

[CreateAssetMenu(menuName = "Managers/Game State")]
public class GameStateSO : ScriptableObject
{
    public GameModeSO CurentGameMode;
    public CitySO ActiveCity;
    public CityRoute ActiveRoute;
}
