using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    /// <summary>
    /// Start is called before the first frame update in a Unity build
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame in a Unity build
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Gets camera rotation values and assigns them to appropriate global variables
    /// </summary>
    void UpdateCameraRotationCordinates()
    {
        Transform camPos = MainCamera.transform;
        float[] currentCordinates = { camPos.rotation.x, camPos.rotation.y, camPos.rotation.z};
        for(int i = 0; i < currentCordinates.Length; i++)
        {
            DeltaXYZ[i] = currentCordinates[i] - PreviousXYZState[i];
            PreviousXYZState[i] = currentCordinates[i];
        }
        
    }
}
