using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour
{
    [HideInInspector]
    NavMeshAgent navMesh;
    public Transform  objetivo;
    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    public void ActualizarDestinoNavMesh(Vector3 puntoDestino)
    {
        navMesh.destination = puntoDestino;        
        navMesh.isStopped = false;
    }
    public void ActualizarDestinoNavMesh()
    {
        ActualizarDestinoNavMesh(objetivo.position);


    }
    public void DetenerNavMesh()
    {
        navMesh.isStopped=true;
    }

    public bool HemosLLegado()
    {
        return navMesh.remainingDistance <= navMesh.stoppingDistance && !navMesh.pathPending;
    }
}
