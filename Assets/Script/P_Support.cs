using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class P_Support : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent navMesh;
    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMesh.destination = Target.position;
        
    }
}
