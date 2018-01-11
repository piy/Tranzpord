using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoutePainter : MonoBehaviour {

    public GameStateSO Game;
    public Vector3Variable Click;
    public TileBase Routes;

    TileBase Roads;
    Tilemap CityTileMap;
    Tilemap routesTileMap;
    Grid m_Grid;

    public void Start()
    {
        Roads = Game.ActiveCity.CityClass.Roads;
        CityTileMap = Game.ActiveCity.CityClass.CityTileMap;
        routesTileMap = Game.ActiveCity.CityClass.CityRoutes;
        m_Grid = Game.ActiveCity.CityClass.m_Grid;
    }



    public void AddTileToActiveRoute()
    {
        if (Game.ActiveGameMode.CurrentGameMode != GameMode.EditRoute)
        {
            return;
        }

        Vector3Int TilePos = m_Grid.WorldToCell(Click.Value);

        if (CityTileMap.GetTile(TilePos) == Roads)
        {
            //ColorTile(newTile);
            Game.ActiveRoute.AddTile(TilePos);
            AddRouteVisual(TilePos);
        }
    }



    public void AddRouteVisual(Vector3Int pos/*, Color color*/)
    {
        var color = Game.ActiveRoute.GetColor();
        routesTileMap.SetTile(pos, Routes);
        routesTileMap.SetColor(pos, color);
        Debug.Log("Adding Route Tile. Pos: " + Click.Value + ". Color: " + color);
    }

}
