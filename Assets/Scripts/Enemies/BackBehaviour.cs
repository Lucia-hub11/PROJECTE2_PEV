using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBehaviour : StateMachineBehaviour
{
    public float backSpeed = 2f;   
    public float backDistance = 3f; 
    /*private float distanceMoved = 0f;*/
    private Vector3 startPosition;
    private Vector3 backTargetPosition;
    private bool isBacking = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //distanceMoved = 0f;
        startPosition = animator.transform.position;
        backTargetPosition = startPosition - animator.transform.forward * backDistance;
        isBacking = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isBacking)
        {
            animator.transform.position = Vector3.MoveTowards(
            animator.transform.position,
            backTargetPosition,
            backSpeed * Time.deltaTime
            );
            if (Vector3.Distance(animator.transform.position, backTargetPosition) < 0.1f)
            {
                isBacking = false;
                //animator.SetBool("goBack", false);
                animator.SetBool("isChasing", true);
            }
        }
        
        //Vector3 backDirection = -animator.transform.forward;
        //Vector3 targetPosition = startPosition + backDirection * backDistance;
        //animator.transform.position = Vector3.MoveTowards(animator.transform.position, targetPosition, backSpeed * Time.deltaTime);

        //float moveAmount = backSpeed * Time.deltaTime; // Distància que es mourà en cada frame
        //animator.transform.Translate(backDirection * moveAmount, Space.World);
        //distanceMoved += moveAmount; // Augmentar la distància recorreguda


        // Si l'enemic ha recorregut la distància especificada, tornar al Chase
        //if (distanceMoved >= backDistance)
        //{
        //    animator.SetBool("goBack", false); // Tornar a "Chase"
        //}
        
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isBacking = false;
        animator.SetBool("goBack", false);
    }

}
