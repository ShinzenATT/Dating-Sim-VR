using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceVariables : MonoBehaviour
{
    public static Camera ActiveCamera { get; private set; }
    public static CameraNodAndShakeDetect NodAndShakeDetectComponent { get; private set; }

    public Camera TargetCamera;
    public Camera FallbackCamera;

    public bool _ObjectStateLogs = true;
    public static bool ObjectStateLogs { get; private set; }

    public bool _CameraLogs = true;
    public static bool CameraLogs { get; private set; }

    public bool _ObjectSensoryLogs = true;
    public static bool ObjectSensoryLogs { get; private set; }

    private static int FrameCounter = 0;
    private const int FrameRate = 90;

    // Start is called before the first frame update
    void Start()
    {
        ActiveCamera = ActiveCameraFinder(TargetCamera, FallbackCamera);

        NodAndShakeDetectComponent = ActiveCamera.GetComponent<CameraNodAndShakeDetect>();

        if(_ObjectStateLogs)
        Debug.Log("NodNShake Component: <color=orange>" + NodAndShakeDetectComponent.ToString() + "</color>");
    }
    
    // Update is called once per frame
    void Update()
    {
        FrameCounterUpdate();

        bool[] currentPermissions = { _ObjectStateLogs, _CameraLogs, _ObjectSensoryLogs };
        UpdateLogPermissions(currentPermissions);
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

    private static void UpdateLogPermissions(bool[] logPermissions)
    {
        for (int i = 0; i < logPermissions.Length; i++)
        {
            bool temp;
            try
            {
                temp = logPermissions[i];
            }
            catch (System.IndexOutOfRangeException)
            {
                break;
            }

            switch (i)
            {
                case 0:
                    ObjectStateLogs = temp;
                    break;
                case 1:
                    CameraLogs = temp;
                    break;
                case 2:
                    ObjectSensoryLogs = temp;
                    break;
                default:
                    throw new System.IndexOutOfRangeException();
            }
        }
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

        if(_ObjectStateLogs)
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
