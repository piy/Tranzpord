using UnityEngine;

public class BusStopBuilder : MonoBehaviour {

    public GameObject BusStop;
    public OwnedBusStops CityBusStopps;

    private void Start()
    {
        Debug.Log("I have: " + CityBusStopps.MyBusStopps.Count + " BusStops");
        BuildAllBusStopps();
    }

    public GameObject CreateBusStop(Vector3Int place)
    {
        var newBusStopInstance = Instantiate(BusStop);
        var newBusStop = newBusStopInstance.GetComponent<CityBusStop>();

        newBusStop.CreateBusStation(place);

        return newBusStopInstance;
    }

    public void BuildBusStop(Vector3Int place)
    {
        var newBusStopInstance = CreateBusStop(place);
        var newBusStop = newBusStopInstance.GetComponent<CityBusStop>();

        CityBusStopps.AddBusStop(newBusStop.myData);
    }

    public void BuildAllBusStopps()
    {
        foreach (var busStop in CityBusStopps.MyBusStopps)
        {
            CreateBusStop(busStop.Placement);
        }
    }
}
