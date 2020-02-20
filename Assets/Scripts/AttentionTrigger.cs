using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AttentionTrigger : MonoBehaviour
{
    public static GameObject PlayerFocus { get; private set; } = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InstanceVariables.FrameTimer(30))
            Debug.Log("PlayerFocus: " + PlayerFocus.ToString());
    }

    private void OnTriggerEnter(Collider focus)
    {
        if (focus.gameObject.tag == "Character")
        {
            Debug.Log("Focus:" + focus.gameObject.ToString());
            PlayerFocus = focus.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.Equals(PlayerFocus))
        {
            PlayerFocus = null;
        }
    }
}
