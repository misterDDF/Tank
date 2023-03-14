using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviTest : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.isStopped = true;
        if (Vector3.Distance(transform.position, target.position) < 10)
        {

        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        }
    }
}
