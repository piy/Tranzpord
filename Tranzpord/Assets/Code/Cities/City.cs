using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class City : MonoBehaviour {

    public GameStateSO game;

    public Vector3Variable Click;

    public TileBase Roads;
    public Tilemap CityTileMap;

    Grid m_Grid;

    private void Start()
    {
        //SHould make check if this exist or Make required component!
        m_Grid = GetComponent<Grid>();
    }

    public void AddTileToActiveRoute()
    {
        if (game.ActiveGameMode.CurrentGameMode != GameMode.EditRoute)
        {
            return;
        }

        Vector3Int newTile = m_Grid.WorldToCell(Click.Value);

        if (CityTileMap.GetTile(newTile) == Roads)
        {
            game.ActiveRoute.AddTile(newTile);
        }
    }
}
