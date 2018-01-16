using UnityEngine;

public class CityBus : MonoBehaviour {

    public BusData myData;
    BusMovement myMovement;

    public void CreateBus()
    {
        myData = new BusData();
        myMovement = gameObject.GetComponent<BusMovement>();
    }

    public void SetNewRoute(CityRouteSO route)
    {
        myData.Route = route;
        myMovement.SetRoute(route);
    }

    //type

    //List of Details
    //Install detail?
    
    //Params: movespeed, max passengers

    //Driver

    //Movement

    //Passengers

    //Current Line
    
}
