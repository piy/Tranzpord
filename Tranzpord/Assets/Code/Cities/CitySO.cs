using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CityEntities/CitySO")]
public class CitySO : ScriptableObject
{
    public List<CityRoute> myRoutes = new List<CityRoute>();
	
}
