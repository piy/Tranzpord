using UnityEngine;
using UnityEngine.Tilemaps;

public class BusStopBuilder : MonoBehaviour {

    public GameStateSO Game;
    public GameObject BusStop;
    public OwnedBusStops CityBusStopps;
    public Vector3Variable ClickCoordinate;

    public Vector3Int placeToBuild = new Vector3Int();

    Grid m_Grid;
    Tilemap CityTileMap;
    TileBase Roads;

    private void OnEnable()
    {
        m_Grid = Game.ActiveCity.CityClass.m_Grid;
        CityTileMap = Game.ActiveCity.CityClass.CityTileMap;
        Roads = Game.ActiveCity.CityClass.Roads;        
    }

    private void Start()
    {
        Debug.Log("I have: " + CityBusStopps.MyBusStopps.Count + " BusStops");
        BuildAllBusStopps();
    }

    //edit bus Stop
    //if tap on road = change placement
    //esle -> (tap on build button) = build Station

    public void ShowBuildBusStopPanel()
    {
        if (Game.ActiveGameMode.CurrentGameMode != GameMode.EditBusStops)
        {
            return;
        }


        if (CityTileMap.GetTile(m_Grid.WorldToCell(ClickCoordinate.Value)) == Roads)
        {
            placeToBuild = m_Grid.WorldToCell(ClickCoordinate.Value);
            //show transperant model and some data (radius and coverage)
            BusStopsEditWindow.Instance.ShowBuildBusStopPanel();
        }
    }


    public void BuildBusStop()
    {
        var newBusStopInstance = CreateBusStop(placeToBuild);
        var newBusStopData = newBusStopInstance.GetComponent<CityBusStop>().myData;

        CityBusStopps.AddBusStop(newBusStopData);
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
