using Cinemachine;
using DigitalRubyShared;
using System.Collections;
using UnityEngine;

public class FingerSetup : MonoBehaviour {

    public Camera MainCamera;
    public GameObject Cam;
    public Vector3 DefaultFocusPoint;

    [Header("Camera Zoom options")]
    public float DefaultZoom;
    public float MaxZoom;
    public float MinZoom;

    private ScaleGestureRecognizer scaleGesture;
    private PanGestureRecognizer panGesture;
    private TapGestureRecognizer tapGesture;
    private Vector3 cameraAnimationTargetPosition;

    private IEnumerator AnimationCoRoutine()
    {
        Vector3 start = Cam.transform.position;

        // animate over 1/2 second
        for (float accumTime = Time.deltaTime; accumTime <= 0.5f; accumTime += Time.deltaTime)
        {
            Cam.transform.position = Vector3.Lerp(start, cameraAnimationTargetPosition, accumTime / 0.5f);
            yield return null;
        }
    }

    private void Start()
    {
        Cam.transform.position = DefaultFocusPoint;

        Cam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = DefaultZoom;

        scaleGesture = new ScaleGestureRecognizer
        {
            ZoomSpeed = 1.0f // for a touch screen you'd probably not do this, but if you are using ctrl + mouse wheel then this helps zoom faster
        };
        scaleGesture.StateUpdated += Gesture_Updated;
        FingersScript.Instance.AddGesture(scaleGesture);

        panGesture = new PanGestureRecognizer();
        panGesture.StateUpdated += PanGesture_Updated;
        FingersScript.Instance.AddGesture(panGesture);

        // the scale and pan can happen together
        scaleGesture.AllowSimultaneousExecution(panGesture);

        tapGesture = new TapGestureRecognizer();
        tapGesture.StateUpdated += TapGesture_Updated;
        FingersScript.Instance.AddGesture(tapGesture);
    }

    private void TapGesture_Updated(GestureRecognizer gesture)
    {
        if (tapGesture.State != GestureRecognizerState.Ended)
        {
            return;
        }

        Ray ray = MainCamera.ScreenPointToRay(new Vector3(tapGesture.FocusX, tapGesture.FocusY, 0.0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // adjust camera x, y to look at the tapped / clicked sphere
            cameraAnimationTargetPosition = new Vector3(hit.transform.position.x, hit.transform.position.y, Cam.transform.position.z);
            StopAllCoroutines();
            StartCoroutine(AnimationCoRoutine());
        }
    }

    private void PanGesture_Updated(GestureRecognizer gesture)
    {
        if (panGesture.State == GestureRecognizerState.Executing)
        {
            StopAllCoroutines();

            // convert pan coordinates to world coordinates
            // get z position, orthographic this is 0, otherwise it's the z coordinate of all the spheres
            float z = (MainCamera.orthographic ? 0.0f : 10.0f);
            Vector3 pan = new Vector3(panGesture.DeltaX, panGesture.DeltaY, z);
            Vector3 zero = MainCamera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, z));
            Vector3 panFromZero = MainCamera.ScreenToWorldPoint(pan);
            Vector3 panInWorldSpace = zero - panFromZero;
            Cam.transform.Translate(panInWorldSpace);
        }
        else if (panGesture.State == GestureRecognizerState.Ended)
        {
            // apply velocity to camera to give it a little extra smooth end to the pan
            Cam.GetComponent<Rigidbody>().velocity = new Vector3(panGesture.VelocityX * -0.002f, panGesture.VelocityY * -0.002f, 0.0f);
        }
    }

    private void Gesture_Updated(GestureRecognizer gesture)
    {
        if (scaleGesture.State != GestureRecognizerState.Executing || scaleGesture.ScaleMultiplier == 1.0f)
        {
            return;
        }

        // invert the scale so that smaller scales actually zoom out and larger scales zoom in
        float scale = 1.0f + (1.0f - scaleGesture.ScaleMultiplier);

        if (MainCamera.orthographic)
        {
            //float newOrthographicSize = Mathf.Clamp(Cam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize * scale, MinZoom, MaxZoom);
            float newOrthographicSize = Cam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize * scale;
            newOrthographicSize = newOrthographicSize.Clamp(MinZoom, MaxZoom);
            Cam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = newOrthographicSize;
        }
        else
        {
            // get camera look vector
            Vector3 forward = Cam.transform.forward;

            // set the target to the camera x,y and 0 z position
            Vector3 target = Cam.transform.position;
            target.z = 0.0f;

            // get distance between camera target and camera position
            float distance = Vector3.Distance(target, Cam.transform.position);

            // come up with a new distance based on the scale gesture
            float newDistance = Mathf.Clamp(distance * scale, 1.0f, 100.0f);

            // set the camera position at the new distance
            Cam.transform.position = target - (forward * newDistance);
        }
    }
}
