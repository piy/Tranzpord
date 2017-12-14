using UnityEngine;

public class LivingHouse : MonoBehaviour {

    public int Residents { get; set; }
    public IntReference DefaultResidents;

    private void Start()
    {
        Residents = DefaultResidents;
        //Check for Current Upgrade Level
    }

    //Current Upgrade Level

    //Upgrade
}
