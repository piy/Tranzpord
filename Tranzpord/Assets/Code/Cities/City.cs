﻿using UnityEngine;
using UnityEngine.Tilemaps;

public class City : MonoBehaviour {

    public GameStateSO game;

    public Vector3Variable Click;

    [Header("TileMaps")]
    public TileBase Roads;
    public Tilemap CityTileMap;
    public Tilemap CityRoutes;

    Grid m_Grid;

    private void Start()
    {
        //SHould make check if this exist or Make required component!
        m_Grid = GetComponent<Grid>();
        game.ActiveCity.CityClass = this;
        HideRoutes();
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
            ColorTile(newTile);
            game.ActiveRoute.AddTile(newTile);
        }
    }

    void ColorTile(Vector3Int TilePos)
    {
        CityTileMap.SetColor(TilePos, Color.red);
    }

    public void ShowRoutes()
    {
        Debug.Log("display route layer");
        CityRoutes.GetComponent<TilemapRenderer>().enabled = true;
    }

    public void HideRoutes()
    {
        Debug.Log("Hide route layer");
        CityRoutes.GetComponent<TilemapRenderer>().enabled = false;
    }
}
