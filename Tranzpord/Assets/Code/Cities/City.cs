using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class City : MonoBehaviour
{
    public RoutePainter Painter;

    [Header("TileMaps")]
    public TileBase Roads;
    public Tilemap CityTileMap;
    public Tilemap CityRoutes;
    public Grid m_Grid;


    private void Start()
    {
        //SHould make check if this exist or Make required component!
        m_Grid = GetComponent<Grid>();
        GameState.Instance.GameData.ActiveCity.CityClass = this;
        LoadCity();
        HideRoutes();
    }



    public void ShowRoutes()
    {
        CityRoutes.GetComponent<TilemapRenderer>().enabled = true;
    }



    public void HideRoutes()
    {
        CityRoutes.GetComponent<TilemapRenderer>().enabled = false;
    }



    public void LoadCity()
    {
        DrawRoutes();
    }



    private void DrawRoutes()
    {
        foreach (var route in GameState.Instance.GameData.ActiveCity.Routes)
        {
            if (route.isUnlocked && route.RouteTiles.Count != 0)
            {
                foreach (var tile in route.RouteTiles)
                {
                    PaintRouteTile(tile, route.GetColor());
                }
            }
        }
    }



    private void PaintRouteTile(Vector3Int tile, Color color)
    {
        CityRoutes.SetTile(tile, Painter.RouteTileSet);
        CityRoutes.SetColor(tile, color);
    }
}
