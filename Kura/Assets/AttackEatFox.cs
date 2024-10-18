using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEatFox : StateMachineBehaviour
{
    float attackRange = 1.5f;
    Transform player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.LookAt(player);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance > attackRange)
        {
            animator.SetBool("isAttacking", false);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
