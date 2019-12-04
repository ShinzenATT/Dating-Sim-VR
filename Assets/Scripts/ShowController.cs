using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ShowController : MonoBehaviour
{
    public bool ShowControllers = false;
    bool ShowControllersState = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ControllerVisibillity();

    }

    void ControllerVisibillity()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (ShowControllers && !ShowControllersState)
            {
                hand.ShowController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
            }
            else if (!ShowControllers && ShowControllersState)
            {
                hand.HideController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithoutController);
            }
        }

        if (ShowControllers != ShowControllersState)
        {
            ShowControllersState = ShowControllers;
        }
    }
}
