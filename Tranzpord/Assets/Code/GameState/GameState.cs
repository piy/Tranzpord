using UnityEngine;

public class GameState : MonoBehaviour {

    private static GameState singleton;

    public GameStateSO GameData;
    public TapInfoSO TapInfo;

    public static GameState Instance
    {
        get
        {
            if (singleton == null)
            {
                GameObject prefab = GameObject.Instantiate(Resources.Load("GameState") as GameObject);
                GameObject.DontDestroyOnLoad(prefab);
                singleton = prefab.GetComponent<GameState>();
            }
            return singleton;
        }
    }
}
