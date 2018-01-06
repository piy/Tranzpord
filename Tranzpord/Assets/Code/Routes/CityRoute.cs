using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CityEntities/Route")]
public class CityRoute : ScriptableObject {

    public bool isUnlocked = false;

    public string RouteName = "Default Route Name";

    public Vector3Variable Offset;
    public List<Vector3Int> RouteTiles = new List<Vector3Int>();

    public void ClearRoute()
    {
        RouteTiles.Clear();
    }

    public void AddTile(Vector3Int tile)
    {
        RouteTiles.Add(tile);
    }

    //Should make some external converter
    public Vector3 GetTilePosition(int index)
    {
        return  RouteTiles[index] + Offset.Value;
    }
}
