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
        /*
        if (InstanceVariables.FrameTimer(30))
            Debug.Log("PlayerFocus: " + PlayerFocus.ToString());
            */
    }

    private void OnTriggerEnter(Collider focus)
    {
        if (focus.gameObject.tag == "Character")
        {
            if(InstanceVariables.CameraLogs)
            Debug.Log("Focus: <color=purple>" + focus.gameObject.ToString() + "</color>");

            PlayerFocus = focus.gameObject;

            focus.gameObject.GetComponent<CharacterProfile>().OnAttention();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.Equals(PlayerFocus))
        {
            PlayerFocus = null;

            other.gameObject.GetComponent<CharacterProfile>().OnLeave();
        }
    }
}
