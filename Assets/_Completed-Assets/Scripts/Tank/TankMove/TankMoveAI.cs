using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMoveAI : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Transform navTarget;

    private void Awake()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();

        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void FixedUpdate()
    {
        if (navTarget != null && !navAgent.isStopped)
        {
            navAgent.SetDestination(navTarget.position);
        }
    }

    public void SetNavTarget(Transform target)
    {
        navTarget = target;
        SetNavActive(target != null);
    }

    public void SetNavSpeed(float speed, float acce)
    {
        navAgent.speed = speed;
        navAgent.acceleration = acce;
    }

    public void SetNavActive(bool isActive)
    {
        navAgent.isStopped = !isActive;
    }
}
