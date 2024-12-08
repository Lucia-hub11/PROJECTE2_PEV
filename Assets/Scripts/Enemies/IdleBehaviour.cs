using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        var playerClose = IsPlayerDetected(animator.transform);
        animator.SetBool("isChasing", playerClose);
        
    }

    private bool IsPlayerDetected(Transform transform)
    {
        return transform.GetComponent<Vision>().IsDetected(); 
    }
}
