using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collections/Buses")]
public class OwnedBuses : ScriptableObject
{
    public List<BusData> MyBusses = new List<BusData>();

    public void AddBus(BusData bus)
    {
        MyBusses.Add(bus);
    }

    public void RemoveBus(BusData bus)
    {
        if (MyBusses.Contains(bus))
        {
            MyBusses.Remove(bus);
        }
        else
            Debug.LogError(bus + " not found in collection of MyBusses");
    }
}
