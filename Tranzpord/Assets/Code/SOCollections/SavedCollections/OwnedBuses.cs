using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collections/Buses")]
public class OwnedBuses : ScriptableObject
{
    public List<GameObject> MyBusses = new List<GameObject>();

    public void AddBus(GameObject bus)
    {
        MyBusses.Add(bus);
    }

    public void RemoveBus(GameObject bus)
    {
        if (MyBusses.Contains(bus))
        {
            MyBusses.Remove(bus);
            Destroy(bus);
        }
        else
            Debug.LogError(bus + " not found in collection of MyBusses");
    }
}
