﻿using UnityEngine;

public class Click : MonoBehaviour {

    public Vector3Variable ClickCoordinates;
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ClickCoordinates.SetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
	}
}
