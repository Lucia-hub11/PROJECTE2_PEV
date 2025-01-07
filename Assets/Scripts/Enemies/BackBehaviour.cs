using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBehaviour : StateMachineBehaviour
{
    public float backSpeed = 2f;   
    public float backDistance = 3f; 
    private Vector3 startPosition;
    private Vector3 backTargetPosition;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        startPosition = animator.transform.position;
        backTargetPosition = startPosition - animator.transform.forward * backDistance;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, backTargetPosition, backSpeed * Time.deltaTime);
        if (Vector3.Distance(animator.transform.position, backTargetPosition) < 0.1f)
        {
            //animator.SetBool("goBack", false);
            animator.SetBool("isChasing", true);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("goBack", false);
    }

}
