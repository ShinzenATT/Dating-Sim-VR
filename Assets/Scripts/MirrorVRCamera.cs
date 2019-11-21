using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class MirrorVRCamera : MonoBehaviour
{
    public Camera TargetCamera;
    private Transform MirrorTransform;
    private Transform SourceTransform;


    // Start is called before the first frame update
    void Start()
    {
        MirrorTransform = GetComponent<Transform>();
        SourceTransform = TargetCamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        UpdateRotation();
        UpdateScale();
        
    }

    private void UpdatePosition()
    {
        MirrorTransform.position = SourceTransform.position;
    }

    private void UpdateRotation()
    {
        MirrorTransform.rotation = SourceTransform.rotation;
    }

    private void UpdateScale()
    {
        MirrorTransform.localScale = SourceTransform.localScale;
    }
}
