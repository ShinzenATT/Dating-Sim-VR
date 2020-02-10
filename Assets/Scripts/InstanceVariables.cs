using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceVariables : MonoBehaviour
{
    public static Camera ActiveCamera { get; private set; }
    public static CameraNodAndShakeDetect NodAndShakeDetectComponent { get; private set; }

    public Camera TargetCamera;
    public Camera FallbackCamera;

    private static int FrameCounter = 0;
    private const int FrameRate = 90;

    // Start is called before the first frame update
    void Start()
    {
        ActiveCamera = ActiveCameraFinder(TargetCamera, FallbackCamera);

        NodAndShakeDetectComponent = ActiveCamera.GetComponent<CameraNodAndShakeDetect>();
        Debug.Log("NodNShake Component: <color=orange>" + NodAndShakeDetectComponent.ToString() + "</color>");
    }
    
    // Update is called once per frame
    void Update()
    {
        FrameCounterUpdate();
    }

    public static bool FrameTimer (int interval)
    {
        bool grant = false;

        if(FrameCounter % interval == 0)
        {
            grant = true;
        }

        return grant;
    }

    private Camera ActiveCameraFinder(Camera targetCam, Camera fallbackCam)
    {
        Camera activeCam;
        if (targetCam.isActiveAndEnabled)
        {
            activeCam = TargetCamera;
        }
        else
        {
            activeCam = fallbackCam;
        }

        Debug.Log("Camera: <color=green>" + activeCam.ToString() + "</color>");

        return activeCam;
    }

    static void FrameCounterUpdate()
    {
        FrameCounter = (++FrameCounter) % FrameRate;
    }

    /*
    public void UpdateVariables()
    {
        Start();
    }
    */
}
