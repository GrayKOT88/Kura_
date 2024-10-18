using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasRunFox : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float attackRange = 1;
    float chaseRange = 25;
    //Transform chick;
    //float chaseRangeChick = 10;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 10;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        //chick = GameObject.FindGameObjectWithTag("Chick").transform;
    }   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < attackRange)
        {
            animator.SetBool("isAttacking",true);
        }
        if(distance > chaseRange)
        {
            animator.SetBool("isChasing", false);
        }

        /*agent.SetDestination(chick.position);
        float distanceChick = Vector3.Distance(animator.transform.position, chick.position);
        if (distanceChick > chaseRangeChick)
        {
            animator.SetBool("isChasing", false);
        }*/
    }   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 2;
    }   
}
