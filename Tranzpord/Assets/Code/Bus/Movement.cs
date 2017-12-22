using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour {

    public FloatReference MoveSpeed;
    public FloatReference TargetAccuracy;

    CityRoute myRoute;

    int nextTileIndex;
    Vector3 targetTile;
    bool shouldMove = false;


    public void SetRoute(CityRoute route)
    {
        myRoute = route;
        nextTileIndex = 0;
        transform.position = myRoute.RouteTiles[nextTileIndex];

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
        
        targetTile = myRoute.RouteTiles[nextTileIndex];
        shouldMove = true;

        StartCoroutine(Move(targetTile));
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

    //Check for Station to Stop
    private bool IsBusStation()
    {
        return true;
    }
    
    //Rotate at corner road
}

