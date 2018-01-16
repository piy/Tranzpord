using UnityEngine;

[CreateAssetMenu(menuName = "Managers/Game Mode")]
public class GameModeSO : ScriptableObject
{
    public GameMode CurrentGameMode = GameMode.PlayMode; 
}

public enum GameMode
{
    PlayMode,
    EditRoute,
    EditBusStops
}

