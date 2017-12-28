﻿using Cinemachine;
using DigitalRubyShared;
using UnityEngine;

public class FingerSetup : MonoBehaviour {

    public GameObject Cam;

    [Header("Camera Zoom options")]
    public float DefaultZoom;
    public float ZoomSensitivity;
    public float MaxZoom;
    public float MinZoom;
    float localScale;

    [Header("Camera Movement options")]

    private TapGestureRecognizer tapGesture;
    private ScaleGestureRecognizer scaleGesture;
    private LongPressGestureRecognizer longPressGesture;


    void Start () {
        CreateTapGesture();
        CreateScaleGesture();
        CreateLongPressGesture();

        localScale = DefaultZoom;
        Cam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = DefaultZoom;
    }

    private void LateUpdate()
    {
        int touchCount = Input.touchCount;
        if (FingersScript.Instance.TreatMousePointerAsFinger && Input.mousePresent)
        {
            touchCount += (Input.GetMouseButton(0) ? 1 : 0);
            touchCount += (Input.GetMouseButton(1) ? 1 : 0);
            touchCount += (Input.GetMouseButton(2) ? 1 : 0);
        }
        string touchIds = string.Empty;
        foreach (Touch t in Input.touches)
        {
            touchIds += ":" + t.fingerId + ":";
        }

        localScale = localScale.Clamp(MinZoom, MaxZoom);
        Cam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = localScale;
    }

    private void DebugText(string text, params object[] format)
    {
        Debug.Log(string.Format(text, format));
    }

#region Tap Gesture
    private void TapGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            DebugText("Tapped at {0}, {1}", gesture.FocusX, gesture.FocusY);
            //CreateAsteroid(gesture.FocusX, gesture.FocusY);
        }
    }

    private void CreateTapGesture()
    {
        tapGesture = new TapGestureRecognizer();
        tapGesture.StateUpdated += TapGestureCallback;
        FingersScript.Instance.AddGesture(tapGesture);
    }
    #endregion

#region Scale Gesture
    private void ScaleGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            //DebugText("Scaled: {0}, Focus: {1}, {2}", scaleGesture.ScaleMultiplier, scaleGesture.FocusX, scaleGesture.FocusY);
            localScale *= scaleGesture.ScaleMultiplier;
        }
    }

    private void CreateScaleGesture()
    {
        scaleGesture = new ScaleGestureRecognizer();
        scaleGesture.StateUpdated += ScaleGestureCallback;
        FingersScript.Instance.AddGesture(scaleGesture);
    }
    #endregion

#region Long Press
    private void LongPressGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Began)
        {
            DebugText("Long press began: {0}, {1}", gesture.FocusX, gesture.FocusY);
            BeginDrag(gesture.FocusX, gesture.FocusY);
        }
        else if (gesture.State == GestureRecognizerState.Executing)
        {
            DebugText("Long press moved: {0}, {1}", gesture.FocusX, gesture.FocusY);
            DragTo(gesture.FocusX, gesture.FocusY);
        }
        else if (gesture.State == GestureRecognizerState.Ended)
        {
            DebugText("Long press end: {0}, {1}, delta: {2}, {3}", gesture.FocusX, gesture.FocusY, gesture.DeltaX, gesture.DeltaY);
            EndDrag(longPressGesture.VelocityX, longPressGesture.VelocityY);
        }
    }

    private void CreateLongPressGesture()
    {
        longPressGesture = new LongPressGestureRecognizer();
        longPressGesture.MaximumNumberOfTouchesToTrack = 1;
        longPressGesture.StateUpdated += LongPressGestureCallback;
        FingersScript.Instance.AddGesture(longPressGesture);
    }
    #endregion

#region Drag
    private void BeginDrag(float screenX, float screenY)
    {
        Vector3 pos = new Vector3(screenX, screenY, 0.0f);
        //pos = Cam.transform.position;
        //longPressGesture.Reset();
    }

    private void DragTo(float screenX, float screenY)
    {
        Vector3 pos = new Vector3(screenX, screenY, 0.0f);
        Cam.transform.position = pos;
    }

    private void EndDrag(float velocityXScreen, float velocityYScreen)
    {
        Vector3 origin = Vector3.zero;
        Vector3 end = Cam.transform.position;
        Vector3 velocity = (end - origin);

        DebugText("Long tap flick velocity: {0}", velocity);
    }
#endregion

    private static bool? CaptureGestureHandler(GameObject obj)
    {
        // I've named objects PassThrough* if the gesture should pass through and NoPass* if the gesture should be gobbled up, everything else gets default behavior
        if (obj.name.StartsWith("PassThrough"))
        {
            // allow the pass through for any element named "PassThrough*"
            return false;
        }
        else if (obj.name.StartsWith("NoPass"))
        {
            // prevent the gesture from passing through, this is done on some of the buttons and the bottom text so that only
            // the triple tap gesture can tap on it
            return true;
        }

        // fall-back to default behavior for anything else
        return null;
    }
}
