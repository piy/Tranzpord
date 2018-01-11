using UnityEngine;

public class Click : MonoBehaviour {

    public GameModeSO mode;
    public Vector3Variable ClickCoordinates;
    public GameEvent PlayClickEvent;
    public GameEvent EditClickEvent;

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ClickCoordinates.SetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (mode.CurrentGameMode == GameMode.PlayMode)
            {
                PlayClickEvent.Raise();
            }

            if (mode.CurrentGameMode == GameMode.EditRoute)
            {
                EditClickEvent.Raise();
            }
            
        }
	}
}
