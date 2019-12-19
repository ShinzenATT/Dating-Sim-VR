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
    public float[] RotationSpeedXYZ { get; } = { 0, 0, 0 };

    /// <summary>
    /// The XYZ readings in the previous frame
    /// </summary>
    /// <remarks>
    /// There are three values in the array which is X, Y and Z rotation in that order
    /// </remarks>
    /// <seealso cref="RotationSpeedXYZ"/>
    private float[] PreviousXYZState = { 0, 0, 0 };
    private int[] Cooldown = { 0, 0, 0 };

    private bool _IsShaking = false;
    public bool IsShaking { get { return _IsShaking; } }

    private bool _IsNodding = false;
    public bool IsNodding { get { return _IsNodding; } }

    private bool _IsTiltShaking = false;
    public bool IsTiltShaking { get { return _IsTiltShaking; } }

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
        AxisShakeCheck(RotationSpeedXYZ[1], ref Cooldown[1], ref _IsShaking);
        AxisShakeCheck(RotationSpeedXYZ[0], ref Cooldown[0], ref _IsNodding);
        AxisShakeCheck(RotationSpeedXYZ[2], ref Cooldown[2], ref _IsTiltShaking);

        if (IsNodding || IsShaking || IsTiltShaking)
        {
            Debug.Log(string.Format("Cooldown: <color=red> {0} </color> <color=green> {1} </color> <color=blue> {2} </color>", Cooldown[0], Cooldown[1], Cooldown[2]));
        }
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
            RotationSpeedXYZ[i] = currentCordinates[i] - PreviousXYZState[i];
            PreviousXYZState[i] = currentCordinates[i];
        }
        
    }

    void AxisShakeCheck(float axisSpeed, ref int cooldown, ref bool status)
    {
        int Direction = 1;
        if(axisSpeed < 0)
        {
            Direction = -1;
        }

        if(Mathf.Abs(axisSpeed) >= 11)
        {
            if(!status && cooldown != 0 && (cooldown < 0 ? -1 : 1) != Direction)
            {
                status = true;
            }

            cooldown = 25 * Direction;
        }
        else if(Mathf.Abs(cooldown) > 0)
        {
            cooldown += (cooldown < 0 ? 1 : -1);
        }
        else if (status && cooldown == 0)
        {
            status = false;
        }


    }
}
