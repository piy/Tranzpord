using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CityEntities/CitySO")]
public class CitySO : ScriptableObject
{
    public City CityClass;
    public List<CityRouteSO> Routes = new List<CityRouteSO>();
    public List<CityBusStation> Stations = new List<CityBusStation>();
    public List<CityBus> Buses = new List<CityBus>();
}
