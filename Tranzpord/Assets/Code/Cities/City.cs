using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class City : MonoBehaviour {

    public Vector3Variable Click;

    public IntReference ActiveRoute;

    public List<CityRoute> CityRoutes = new List<CityRoute>();

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
        //SHould check If I've tapped the roude tile
        Vector3Int newTile = m_Grid.WorldToCell(Click.Value);
        CityRoutes[ActiveRoute].AddTile(newTile);
    }
}
