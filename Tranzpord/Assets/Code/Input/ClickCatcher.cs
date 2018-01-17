using UnityEngine;

public class ClickCatcher : MonoBehaviour {

    public GameModeSO mode;

    public GameEvent PlayClickEvent;
    public GameEvent EditRouteClickEvent;
    public GameEvent EditBusStopClickEvent;

    public void RaiseProperClickEvent()
    {
        if (mode.CurrentGameMode == GameMode.PlayMode)
        {
            PlayClickEvent.Raise();
        }

        if (mode.CurrentGameMode == GameMode.EditRoute)
        {
            EditRouteClickEvent.Raise();
        }

        if (mode.CurrentGameMode == GameMode.EditBusStops)
        {
            EditBusStopClickEvent.Raise();
        }
    }
}
