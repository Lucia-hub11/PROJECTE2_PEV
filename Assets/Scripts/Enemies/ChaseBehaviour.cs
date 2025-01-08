using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour
{
    private Transform WP_target;
    public float Speed = 2;
    public bool Move2D;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vision vision = animator.GetComponent<Vision>();
        WP_target = vision.WayPoint;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyDestruction enemyDestruction = animator.GetComponent<EnemyDestruction>();
        bool playerHere = enemyDestruction.IsPlayerHere();
        if (!playerHere)
        {
            Move(animator, WP_target);
        }
        else
        {
            animator.SetBool("goBack", true);
            animator.SetBool("isChasing", false); 
        }

    }
    private void Move(Animator animator, Transform target)
    {
        Vector3 targetPosition = target.position;
        if (Move2D)
            targetPosition.y = animator.transform.position.y;
        animator.transform.LookAt(targetPosition);
        animator.transform.Translate(animator.transform.forward * Speed * Time.deltaTime, Space.World);
    }

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //animator.SetBool("goBack", false);
    //    animator.SetBool("isChasing", false);
    //}
}
