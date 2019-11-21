using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Camera))]
public class CameraNodAndShakeDetect : MonoBehaviour
{

    /// <summary>
    /// The camera selected in the Unity editor
    /// </summary>
    public Camera MainCamera;

    /// <summary>
    /// Speed in rotation (X is horizontal rotation, Y is vertical rotation and Z is tilting)
    /// </summary>
    /// <remarks>
    /// There are three values in the array which is X, Y and Z rotation in that order
    /// </remarks>
    private float[] DeltaXYZ = {0, 0, 0 };
    /// <summary>
    /// The XYZ readings in the previous frame
    /// </summary>
    /// <remarks>
    /// There are three values in the array which is X, Y and Z rotation in that order
    /// </remarks>
    /// <seealso cref="DeltaXYZ"/>
    private float[] PreviousXYZState = { 0, 0, 0 };
    private int[] Cooldown = { 0, 0, 0 };

    bool _IsShaking = false;
    public bool IsShaking { get
        {
            return _IsShaking;
        } }

    bool _IsNodding = false;
    public bool IsNodding { get
        {
            return _IsNodding;
        } }

    bool _IsTilted = false;
    public bool IsTilted
    {  get
        {
            return _IsTilted;
        } }

    /// <summary>
    /// Start is called before the first frame update in a Unity build
    /// </summary>
    void Start()
    {
        UpdateCameraRotationCordinates();
    }

    /// <summary>
    /// Update is called once per frame in a Unity build
    /// </summary>
    void Update()
    {
        UpdateCameraRotationCordinates();
    }

    /// <summary>
    /// Gets camera rotation values and assigns them to appropriate global variables
    /// </summary>
    void UpdateCameraRotationCordinates()
    {
        Transform camPos = MainCamera.transform;
        float[] currentCordinates = { camPos.eulerAngles.x, camPos.eulerAngles.y, camPos.eulerAngles.z};
        for(int i = 0; i < currentCordinates.Length; i++)
        {
            DeltaXYZ[i] = currentCordinates[i] - PreviousXYZState[i];
            PreviousXYZState[i] = currentCordinates[i];
        }
        
    }

    void AxisShakeCheck(float axisSpeed, ref int cooldown, ref bool status)
    {
        bool PositiveDirection = true;
        if(axisSpeed < -0.00001)
        {
            PositiveDirection = false;
        }

    }

    public float[] GetAxisSpeeds()
    {
        return DeltaXYZ;
    }
}
