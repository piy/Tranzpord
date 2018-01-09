using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CityEntities/CitySO")]
public class CitySO : ScriptableObject
{
    public List<CityRoute> Routes = new List<CityRoute>();
	
}
