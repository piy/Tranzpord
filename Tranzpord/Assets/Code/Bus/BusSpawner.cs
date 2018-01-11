using UnityEngine;

public class BusSpawner : MonoBehaviour {

    public GameObject Bus;
    public CityRouteSO ActiveRoute;

    public void SpawnBus()
    {
        var newBas = Instantiate(Bus);
        newBas.GetComponent<BusMovement>().SetRoute(ActiveRoute);
    }
}
