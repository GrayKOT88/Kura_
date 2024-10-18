using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleFox : StateMachineBehaviour
{
    float time;
    Transform player;
    //Transform chick;
    float chaseRange = 25;
    //float chaseRangeChick = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //chick = GameObject.FindGameObjectWithTag("Chick").transform;
    }    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if(time > 5)
        {
            animator.SetBool("isPatrolling", true);
        }
        float distance = Vector3.Distance(animator.transform.position, player.transform.position); //Player
        if(distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
        /*float distanceChick = Vector3.Distance(animator.transform.position, chick.transform.position); //Chick
        if(distanceChick < chaseRangeChick)
        {
            animator.SetBool("isChasing", true);
        }*/

    }    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
   
}
