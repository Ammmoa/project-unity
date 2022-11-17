using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ctrlENI : MonoBehaviour
{
    //components
    private Animator animator;

    //references
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatisground, whatisplayer;
    public MeshCollider coll;

    //patroling
    public Transform[] waypoints;
    private int waypointsindex;
    private float dist;

    //****
    private static ctrlENI instance = null;
    
    //states
    public float sightrange, attackrange;
    public bool playerDetected;

    private void Start()
    {
        //components
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //patroling
        waypointsindex = 0;
        transform.LookAt(waypoints[waypointsindex].position);

    }

    private void Update()
    {
        //patrolling
        dist = Vector3.Distance(transform.position, waypoints[waypointsindex].position);
        if (dist < 1f)
            increaseindex();

        //player insight range
        playerDetected = playerdetect.getInstance().isPlayerDetected;
        if (!playerDetected) patrol();
            animator.SetBool("move", true);
        //if (playerDetected) chaseplayer();                   // <---------------
          //  animator.SetBool("move", true);                  //when enemy reaches patrolling point, it somehow continues moving 
    }     //there is no need of it                            //by previous direction by inertion while it starts rotate when reaches the point

    //patroling function
    private void patrol()
    {
        Debug.Log("patrol " + waypoints[waypointsindex].transform.position);
        agent.SetDestination(waypoints[waypointsindex].transform.position);
        
    }
    private void increaseindex()
    {
        waypointsindex++;
        if (waypointsindex >= waypoints.Length)
            waypointsindex = 0;
        transform.LookAt(waypoints[waypointsindex].position);
    } 
    //end patrolling function
    private void chaseplayer()
    {
        agent.SetDestination(player.transform.position);
    }
    public static ctrlENI getInstance()
    {
        return instance;
    }

    //for mines
    public void explosion()
    {
        Destroy(gameObject);
    }

    //is activated button ''restart''
    public void restart()
    {
        gameObject.SetActive(true);
    }
}
