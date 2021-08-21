using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target; // 1
    [SerializeField] private float chaseRange = 5f; // 2

    private NavMeshAgent navMeshAgent; // 1
    private float distanceToTarget = Mathf.Infinity; // 2

    private bool isProvoked = false;

    /// 5
    ///
    private float turnSpeed = 5f; // 15

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // 1
    }

    void Update()
    {
        // navMeshAgent.SetDestination(target.position); // 1

        // distance between the player (target) and the enemy
        distanceToTarget = Vector3.Distance(target.position, transform.position); // 2

        // 2 Complete the logic challenge
        //  Add an if statement to make our enemy move if the player gets within range
        //if (distanceToTarget <= chaseRange)
        //{
        //    navMeshAgent.SetDestination(target.position);
        //}

        // 4 Enemy Behaviour - Provoked
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    // 4 Provoked
    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    // 4
    private void ChaseTarget()
    {
        // 4
        //Debug.Log(name + " has chased " + target.name);
        //navMeshAgent.SetDestination(target.position);

        // 9
        Debug.Log(name + " has chased " + target.name);
        navMeshAgent.SetDestination(target.position);
        GetComponent<Animator>().SetBool("Attack_Bool", false);
        GetComponent<Animator>().SetTrigger("Move_Trigger");
    }

    // 4
    private void AttackTarget()
    {
        // 4
        //Debug.Log(name + " has seeked and is destroying " + target.name);

        // 9
        Debug.Log(name + " has seeked and is destroying " + target.name);
        GetComponent<Animator>().SetBool("Attack_Bool", true);
    }

    // 3 Draw Gizmo to show the chase range
    void OnDrawGizmosSelected()
    {
        // Display the chase range status when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void FaceTarget()
    {
        // 15
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
}
