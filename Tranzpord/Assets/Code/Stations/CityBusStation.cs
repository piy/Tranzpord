using UnityEngine;

public class CityBusStation : MonoBehaviour {

    public float Range { get; set; }
    public FloatReference DefaultRange;

    public int CitizenCoverage { get; set; }

    private void Start()
    {
        Range = DefaultRange;
        CalculateCoverageResidents();
    }

    //Params: Coverage range, max clients, 
    //Houses nearby
    //List of all the parts installed

    void CalculateCoverageResidents()
    {
        CitizenCoverage = 0;
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, Range);
    }
}
