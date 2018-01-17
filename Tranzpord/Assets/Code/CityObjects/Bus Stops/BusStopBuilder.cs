using UnityEngine;
using UnityEngine.Tilemaps;

public class BusStopBuilder : MonoBehaviour {

    public GameStateSO Game;
    public GameObject BusStop;
    public OwnedBusStops CityBusStopps;
    public Vector3Variable ClickCoordinate;


    Grid m_Grid;
    Tilemap CityTileMap;
    TileBase Roads;

    private void Start()
    {
        m_Grid = Game.ActiveCity.CityClass.m_Grid;
        CityTileMap = Game.ActiveCity.CityClass.CityTileMap;
        Roads = Game.ActiveCity.CityClass.Roads;

        Debug.Log("I have: " + CityBusStopps.MyBusStopps.Count + " BusStops");
        BuildAllBusStopps();
    }

    public void ShowBuildBusStopPanel()
    {
        if (Game.ActiveGameMode.CurrentGameMode != GameMode.EditBusStops)
        {
            return;
        }

        Vector3Int pos = m_Grid.WorldToCell(ClickCoordinate.Value);

        if (CityTileMap.GetTile(pos) == Roads)
        {
            BusStopsEditWindow.Instance.ShowBuildBusStopPanel();
        }
    }


    public void BuildBusStop()
    {
        Vector3Int pos = m_Grid.WorldToCell(ClickCoordinate.Value);

        var newBusStopInstance = CreateBusStop(pos);
        var newBusStop = newBusStopInstance.GetComponent<CityBusStop>();
        newBusStop.myData.Placement = pos;

        CityBusStopps.AddBusStop(newBusStop.myData);
        BusStopsEditWindow.Instance.HideBuildBusStopPanel();
    }

    public GameObject CreateBusStop(Vector3Int place)
    {
        var newBusStopInstance = Instantiate(BusStop);
        var newBusStop = newBusStopInstance.GetComponent<CityBusStop>();

        newBusStop.CreateBusStation(place);

        return newBusStopInstance;
    }


    public void BuildAllBusStopps()
    {
        foreach (var busStop in CityBusStopps.MyBusStopps)
        {
            CreateBusStop(busStop.Placement);
        }
    }
}
