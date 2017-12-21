using UnityEngine;

public class Movement : MonoBehaviour {

    public FloatReference MoveSpeed;

    CityRoute myRoute;

    int nextTileIndex;
    Vector3 targetTile;
    bool shouldMove = false;

    private void Update()
    {
        if (shouldMove == false)
            return;

        if (transform.position != targetTile)
        {
            //transform.Translate(targetTile * Time.deltaTime * MoveSpeed);
        } else
        SetNextTile();
    }

    public void SetRoute(CityRoute route)
    {
        myRoute = route;
        nextTileIndex = 0;
        transform.position = myRoute.RouteTiles[nextTileIndex];

        SetNextTile();
    }

    void MoveToNextTile()
    {

    }

    void SetNextTile()
    {
        if (nextTileIndex < myRoute.RouteTiles.Count)
        {
            nextTileIndex++;
        }
        else
        {
            nextTileIndex = 0; //should move backward
        }
        
        targetTile = myRoute.RouteTiles[nextTileIndex];
        shouldMove = true;
    }

    //Check for Station to Stop

    //Rotate

}

