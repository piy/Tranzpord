using UnityEngine;

public class BusSpawner : MonoBehaviour {

    public GameObject Bus;
    public CityRoute ActiveRoute;

    public void SpawnBus()
    {
        var newBas = Instantiate(Bus);
        newBas.GetComponent<Movement>().SetRoute(ActiveRoute);
    }
}
