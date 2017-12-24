using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class City : MonoBehaviour {

    public Vector3Variable Click;

    public IntReference ActiveRoute;

    public List<CityRoute> CityRoutes = new List<CityRoute>();

    public TileBase Roads;
    public Tilemap CityTileMap;

    Grid m_Grid;

    private void Start()
    {
        //Clearing all Routes (should load from save)
        for (int i = 0; i < CityRoutes.Count; i++)
        {
            CityRoutes[i].ClearRoute();
        }

        //SHould make check if this exist or Make required component!
        m_Grid = GetComponent<Grid>();
    }

    public void AddTileToActiveRoute()
    {
        Vector3Int newTile = m_Grid.WorldToCell(Click.Value);

        if (CityTileMap.GetTile(newTile) == Roads)
        {
            CityRoutes[ActiveRoute].AddTile(newTile);
        }
    }
}
