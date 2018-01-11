using UnityEngine;
using UnityEngine.Tilemaps;

public class RoutePainter : MonoBehaviour {

    public GameStateSO Game;
    public Vector3Variable Click;
    public RuleTile RouteTileSet;

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



    public void EditRoute()
    {
        if (Game.ActiveGameMode.CurrentGameMode != GameMode.EditRoute)
        {
            return;
        }

        Vector3Int TilePos = m_Grid.WorldToCell(Click.Value);

        if (CityTileMap.GetTile(TilePos) == Roads)
        {
            if (Game.ActiveRoute.RouteTiles.Count == 0)
            {
                //Start Route anywhere
                //to do: check if there is already more than 3 routes -> disallow and show message
                AddTileToARoute(TilePos);
            }
            else
            {
                AddTileToARoute(TilePos);  //Just so it'll work as was

                //check if this tile is connected to the ends of the Route.
                //Check if Im not clicking on the already existing Tile -> then try to remove it (also check if it's not in a middle of the route).
            }

        }
        else //Click not on a road
        {
            ShowInvalidTile(TilePos, "Not a Road");
        }
    }

    private void AddTileToARoute(Vector3Int pos)
    {
        Game.ActiveRoute.AddTile(pos);
        AddRouteVisual(pos);
    }

    public void AddRouteVisual(Vector3Int pos)
    {
        color = Game.ActiveRoute.GetColor();

        routesTileMap.SetTile(pos, RouteTileSet);
        routesTileMap.SetColor(pos, color);
    }

    private bool IsTileValid(Vector3Int pos)
    {
        if (CityTileMap.GetTile(pos) == Roads)
        {
            return true;
        }

        return true;
    }

    private void ShowInvalidTile(Vector3Int pos, string explain)
    {
        //Show animation/effect
        Debug.Log(explain + pos);
    }
}
