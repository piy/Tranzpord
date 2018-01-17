using UnityEngine;

public class Click : MonoBehaviour {

    public GameModeSO mode;
    public Vector3Variable ClickCoordinates;
    public GameEvent ClickEvent;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickCoordinates.SetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            ClickEvent.Raise();
        }
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //var ray = cam.ScreenToWorldPoint(Input.mousePosition);
    //        //RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

    //        var focus = EventSystem.current.;

    //        if (focus)
    //        {
    //            Debug.Log(focus);
    //        }

    //        ClickCoordinates.SetValue(cam.ScreenToWorldPoint(Input.mousePosition));
    //        ClickEvent.Raise();
    //    }
    //}
}
