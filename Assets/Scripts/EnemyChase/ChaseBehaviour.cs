
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
        Move(animator, WP_target);
    }
    private void Move(Animator animator, Transform target)
    {
        Vector3 targetPosition = target.position;
        if (Move2D) //si es vol moure nomes en la y (no jump)
            targetPosition.y = animator.transform.position.y;
        animator.transform.LookAt(targetPosition);
        animator.transform.Translate(animator.transform.forward * Speed * Time.deltaTime, Space.World);
    }
}
