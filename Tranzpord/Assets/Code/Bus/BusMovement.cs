using System.Collections;
using UnityEngine;

public class BusMovement : MonoBehaviour {

    public FloatReference MoveSpeed;
    public FloatReference TargetAccuracy;

    CityRouteSO myRoute;

    int nextTileIndex;


    /// <summary>
    /// Methods
    /// </summary>
    /// <param name="route"></param>
    public void SetRoute(CityRouteSO route)
    {
        myRoute = route;
        nextTileIndex = 0;
        transform.position = myRoute.GetTilePosition(nextTileIndex);

        SetNextTile();
    }



    void SetNextTile()
    {
        if (nextTileIndex < myRoute.RouteTiles.Count - 1)
        {
            nextTileIndex++;
        }
        else
        {
            nextTileIndex = 0; //should move backward
        }
       
        StartCoroutine(Move(GetTargetPosition()));
    }



    IEnumerator Move(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > TargetAccuracy)
        {
            Vector3 dir = target - transform.position;
            transform.Translate(dir.normalized * MoveSpeed * Time.deltaTime, Space.World);
            //transform.position = Vector3.Lerp(transform.position, target, MoveSpeed * Time.deltaTime);

            yield return null;
        }

        if (IsBusStation())
        {
            yield return new WaitForSeconds(0.1f);
        }

        SetNextTile();
    }



    Vector3 GetTargetPosition()
    {
        return myRoute.GetTilePosition(nextTileIndex);
    }


    //Check for Station to Stop
    private bool IsBusStation()
    {
        return true;
    }
    


    //Rotate at corner road
}

