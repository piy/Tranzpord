using UnityEngine;

public class BusSpawner : MonoBehaviour {

    public GameObject Bus;
    public OwnedBuses CityBusses;
    //public CityRouteSO ActiveRoute;

    public void SpawnBus()
    {
        var newBus = Instantiate(Bus);
        var route = gameObject.GetComponent<RouteEditWindow>().game.ActiveRoute;

        newBus.GetComponent<BusMovement>().SetRoute(route);
        CityBusses.AddBus(newBus);
    }
}
