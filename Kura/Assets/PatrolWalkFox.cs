using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolWalkFox : StateMachineBehaviour
{
    float time;
    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    float chaseRange = 25;
    //Transform chick;
    //float chaseRangeChick = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform t in pointsObject)
        {
            points.Add(t);
        }
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[Random.Range(0, points.Count)].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        //chick = GameObject.FindGameObjectWithTag("Chick").transform;
    }    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance) 
        {
            agent.SetDestination(points[Random.Range(0, points.Count)].position);
        }
        time += Time.deltaTime;
        if(time > 180)
        {
            animator.SetBool("isPatrolling",false);
        }
        float distance = Vector3.Distance(animator.transform.position, player.position); //Player
        if(distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
        /*float distanceChick = Vector3.Distance(animator.transform.position, chick.position); //Chick
        if (distanceChick < chaseRangeChick)
        {
            animator.SetBool("isChasing", true);
        }*/
    }    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }   
}
