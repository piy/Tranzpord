using UnityEngine;
using UnityEngine.Tilemaps;

public class RoutePainter : MonoBehaviour {

    public GameStateSO Game;
    public Vector3Variable Click;
    public RuleTile Routes;

    TileBase Roads;
    Tilemap CityTileMap;
    Tilemap routesTileMap;
    Grid m_Grid;

    Color color;

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
            Game.ActiveRoute.AddTile(TilePos);
            AddRouteVisual(TilePos);
        }
    }



    public void AddRouteVisual(Vector3Int pos)
    {
        color = Game.ActiveRoute.GetColor();

        var newTile = ScriptableObject.CreateInstance<Tile>();
        newTile.color = color;
        newTile.sprite = Routes.m_DefaultSprite;

        //routesTileMap.SetTile(pos, newTile);
        routesTileMap.SetTile(pos, Routes);
        routesTileMap.SetColor(pos, color);
        //routesTileMap.RefreshAllTiles();
    }

}
