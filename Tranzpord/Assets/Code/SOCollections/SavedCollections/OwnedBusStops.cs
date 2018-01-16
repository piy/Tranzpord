using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collections/BusStops")]
public class OwnedBusStops : ScriptableObject
{
    public List<BusStopData> MyBusStopps = new List<BusStopData>();

    public void AddBusStop(BusStopData busStop)
    {
        MyBusStopps.Add(busStop);
    }

    public void RemoveBusStop(BusStopData busStop)
    {
        if (MyBusStopps.Contains(busStop))
        {
            MyBusStopps.Remove(busStop);
        }
        else
            Debug.LogError(busStop + " not found in collection of MyBusStopps");
    }
}
