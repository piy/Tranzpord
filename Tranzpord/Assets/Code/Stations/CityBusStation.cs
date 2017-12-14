using System.Collections.Generic;
using UnityEngine;

public class CityBusStation : MonoBehaviour {

    public HouseRuntimeCollection CityHouses;

    public float Range { get; set; }
    public FloatReference DefaultRange;

    public int CitizenCoverage { get; set; }

    private List<LivingHouse> HousesInRange = new List<LivingHouse>();

    //Params: Coverage range, max clients, 
    //List of all the parts installed

    private void Start()
    {
        Range = DefaultRange;
        CalculateCoverageResidents();
    }

    void CalculateCoverageResidents()
    {
        FindHousesInRange();

        if (HousesInRange.Count != 0)
        {
            foreach (var house in HousesInRange)
            {
                CitizenCoverage += house.Residents;
            }

        } else CitizenCoverage = 0;
    }

    void FindHousesInRange()
    {
        if (CityHouses.IsNotEmpty())
        {
            for (int i = 0; i < CityHouses.Items.Count; i++)
            {
                float dist = (transform.position - CityHouses.Items[i].transform.position).magnitude;

                if (dist <= Range)
                {
                    HousesInRange.Add(CityHouses.Items[i]);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, Range);
    }
}
