using UnityEngine;
using UnityEngine.Tilemaps;

public class City : MonoBehaviour {

    public GameStateSO game;

    public Vector3Variable Click;

    [Header("TileMaps")]
    public TileBase Roads;
    public Tilemap CityTileMap;
    public Tilemap CityRoutes;
    public Grid m_Grid;



    private void Start()
    {
        //SHould make check if this exist or Make required component!
        m_Grid = GetComponent<Grid>();
        game.ActiveCity.CityClass = this;
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
}
