using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    private Transform Transform;
    private Camera ActiveCamera;
    // Start is called before the first frame update
    void Start()
    {
        /*
        var temp = GetComponent<Transform>();
        if(temp == null)
        {
            Transform = GetComponent<RectTransform>();
        }
        else
        {
            Transform = temp;
        }
        */
        Transform = gameObject.transform;

        ActiveCamera = InstanceVariables.ActiveCamera;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = GetAngle(
            GetTopDownPositions(Transform),
            GetTopDownPositions(ActiveCamera.transform)
            );

        Vector3 rotation = Transform.transform.eulerAngles;
        rotation.y = angle;
        Transform.transform.eulerAngles = rotation;

        /*
        if (InstanceVariables.FrameTimer(10))
        {
            Debug.Log("Angle: <color=orange>" + angle + 
                "</color> \n" + ActiveCamera.transform.position.ToString() + "\n" + Transform.position.ToString());
        }
        */
    }

    float[] GetTopDownPositions(Transform GameObject)
    {
        float[] cordinates = { GameObject.position.x, GameObject.position.z };
        return cordinates;
    }

    float[] GetTopDownPositions(Component component)
    {
        return GetTopDownPositions(component.transform);
    }

    float GetAngle(float[] StationaryObjectCordinates, float[] MovingObjectCordinates)
    {
        float[] Distance = {
            MovingObjectCordinates[0] - StationaryObjectCordinates[0],
            MovingObjectCordinates[1] - StationaryObjectCordinates[1]
        };

        float angle = (Mathf.Atan(Distance[0] / Distance[1])) * Mathf.Rad2Deg;
        int modifier = 0;

        if(Distance[0] < 0 && Distance[1] < 0)
        {
            modifier = 180;
        }
        else if(Distance[1] < 0 && Distance[0] >= 0)
        {
            modifier = -180;
        }

        if (InstanceVariables.FrameTimer(15))
            Debug.Log("Angle: <color=orange>" + angle +
                    "</color> \n" + Distance[0] + ' ' + Distance[1]);
        
        return angle + modifier;
    }
}
