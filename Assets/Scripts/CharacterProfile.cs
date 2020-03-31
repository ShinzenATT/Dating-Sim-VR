using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(RotateTowardsPlayer))]
public class CharacterProfile : MonoBehaviour
{
    public string DialogTreeRoot;
    public int _DialogTree = 0;
    public int CurrentDialog = 0;

    public bool CurrentlyInInteraction = false;

    private Animator animator;
    private AnimatorStateInfo currentState;
    private AnimatorStateInfo previousState;

    private RotateTowardsPlayer RotateTowardsPlayer;
    private Quaternion BaseRotation;

    // Start is called before the first frame update
    void Start()
    {
        BaseRotation = gameObject.transform.rotation;

        animator = GetComponent<Animator>();
        currentState = animator.GetCurrentAnimatorStateInfo(0);
        previousState = currentState;

        RotateTowardsPlayer = GetComponent<RotateTowardsPlayer>();

        RotateTowardsPlayer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Next"))
        {
            currentState = animator.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                animator.SetBool("Next", false);
                previousState = currentState;
            }
        }

        if (animator.GetBool("Back"))
        {
            currentState = animator.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                animator.SetBool("Back", false);
                previousState = currentState;
            }
        }

    }

    public void OnAttention()
    {
        if (!CurrentlyInInteraction)
        {
            animator.SetBool("Next", true);
        }

        RotateTowardsPlayer.enabled = true;
        CurrentlyInInteraction = true;

        string dialog = DialogTree.DialogTrees[0][0];
        Debug.Log(dialog);
    }

    public void OnLeave()
    {
        if (CurrentlyInInteraction)
        {
            animator.SetBool("Back", true);
        }

        RotateTowardsPlayer.enabled = false;
        CurrentlyInInteraction = false;

        gameObject.transform.rotation = BaseRotation;
    }
}
