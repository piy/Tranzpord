using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CityEntities/Route")]
public class CityRoute : ScriptableObject {

    public List<Vector3Int> RouteTiles = new List<Vector3Int>();

    public void ClearRoute()
    {
        RouteTiles.Clear();
    }

    public void AddTile(Vector3Int tile)
    {
        RouteTiles.Add(tile);
    }
}
