using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] Transform[] TransformPath;
    NavMeshAgent navMeshAgent;
    EnemyHealth health;
    Transform target;
    ZombieNum zNum;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked;
    int currentPath = 0;
    void Start()
    {
        zNum = FindObjectOfType<ZombieNum>();
        zNum.ZCount();
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        if (TransformPath.Length != 0)
        {
            navMeshAgent.SetDestination(TransformPath[currentPath].position);
            GetComponent<Animator>().SetTrigger("move");
        }
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
            EngageTarget();
        else if (distanceToTarget <= chaseRange)
            isProvoked = true;
        else if (TransformPath.Length > 1)
            Patrol();

    }

    void EngageTarget()
    {
        FaceTaregt();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
            ChaseTarget();
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
            AttackTarget();
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        if (navMeshAgent.enabled)
            navMeshAgent.SetDestination(target.position);
        GetComponent<NavMeshAgent>().speed = 5;
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        // Debug.Log("Attack");
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void FaceTaregt()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    void Patrol()
    {
        if (Vector3.Distance(GetComponent<Transform>().position, TransformPath[currentPath].position) <= 5)
        {
            if (currentPath + 1 < TransformPath.Length)
                currentPath++;
            else
                currentPath = 0;
            navMeshAgent.SetDestination(TransformPath[currentPath].position);
        }
        /*if (Vector3.Distance(GetComponent<Transform>().position, TransformPath[2].position) <= 2)
        {
            navMeshAgent.SetDestination(TransformPath[0].position);
        }
        else if (Vector3.Distance(GetComponent<Transform>().position, TransformPath[0].position) <= 2)
        {
            navMeshAgent.SetDestination(TransformPath[1].position);
        }
        else if (Vector3.Distance(GetComponent<Transform>().position, TransformPath[1].position) <= 2)
        {
            navMeshAgent.SetDestination(TransformPath[2].position);
        }*/
    }
}
