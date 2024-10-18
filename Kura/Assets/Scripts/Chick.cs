using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chick : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;
    Animator playerAnim;    
    Counter counter;
    [SerializeField] ParticleSystem explosionParticle;    
    int pointValue = 1;
    void Start()
    {
        counter = GameObject.Find("Counter").GetComponent<Counter>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        playerAnim = GetComponent<Animator>();        
    }    
    void Update()
    {       
        float distanse = Vector3.Distance(transform.position, player.position);
        if (distanse >= 10)
        {
            playerAnim.SetFloat("Speed_f", 0);
        }
        if (distanse < 10)
        {
            agent.SetDestination(player.position);
            playerAnim.SetFloat("Speed_f", 1);
        }
        if (distanse <= 1)
        {
            agent.SetDestination(agent.transform.position);
            playerAnim.SetFloat("Speed_f", 0);
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox"))
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            counter.UpdateScore(pointValue);
        }        
    }   
}
