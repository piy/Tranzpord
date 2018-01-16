using UnityEngine;

public class BusSpawner : MonoBehaviour {

    public GameObject Bus;
    public OwnedBuses CityBusses;

    private void Start()
    {
        Debug.Log("I have: " + CityBusses.MyBusses.Count + " Busses");
        SpawnAllBusses();
    }

    public GameObject CreateBus(CityRouteSO route)
    {
        var newBusInstance = Instantiate(Bus);
        var newBus = newBusInstance.GetComponent<CityBus>();

        newBus.CreateBus();
        newBus.SetNewRoute(route);

        return newBusInstance;
    }

    public void SpawnBus(CityRouteSO route)
    {
        var newBusInstance = CreateBus(route);
        var newBus = newBusInstance.GetComponent<CityBus>();

        CityBusses.AddBus(newBus.myData);
    }

    public void SpawnAllBusses()
    {
        foreach (var bus in CityBusses.MyBusses)
        {
            CreateBus(bus.Route);
        }
    }
}
