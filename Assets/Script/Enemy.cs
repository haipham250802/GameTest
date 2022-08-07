using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent navMesh;
    public float distance;
    public EnemyState stateEnemy = EnemyState.IDLE;
    Animator anm;

    public float offSettarget = 5;
    private void Awake()
    {
        stateEnemy = EnemyState.IDLE;
        navMesh = GetComponent<NavMeshAgent>();
        anm = GetComponent<Animator>();
    }

    void Update()
    {
       if(stateEnemy == EnemyState.Run)
        {
            navMesh.destination = Target.position;
            distance = Vector3.Distance(Target.position, transform.position);
            if (distance < offSettarget)
            {
                ChangeState(EnemyState.Attack);
            }
        }
        if (stateEnemy == EnemyState.IDLE)
        {
            distance = Vector3.Distance(Target.position, transform.position);
            if (distance > offSettarget)
            {
                ChangeState(EnemyState.Run);
            }
        }
    }
    void ChangeState(EnemyState enmSt)
    {
        stateEnemy = enmSt;
        switch (enmSt)
        {
            case EnemyState.IDLE:
                anm.SetTrigger("IDLE");
                break;
            case EnemyState.Attack:
                anm.SetTrigger("Attack");
                ChangeState(EnemyState.IDLE);
                break;
            case EnemyState.Run:
                anm.SetTrigger("Run");
                break;
        }
    }
}

public enum EnemyState
{
    IDLE,
    Attack,
    Run
}