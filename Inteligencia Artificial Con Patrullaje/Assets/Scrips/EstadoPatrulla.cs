using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrulla : MonoBehaviour
{
    public Transform[] wayPoints;
    ControladorNavMesh controladorNavMesh;
    int siguienteWayPoint;
    ControladorMaquinaEstados MaquinaEstados;
    ControladorVision controladorVision;
    void Awake()
    {
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        MaquinaEstados = GetComponent<ControladorMaquinaEstados>();
        controladorVision = GetComponent<ControladorVision>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(controladorVision.PuedeVerAljugador(out hit))
        {
            controladorNavMesh.objetivo = hit.transform;
            MaquinaEstados.activarEstado(MaquinaEstados.estadoPersecucion);
            return;
        }
        if(controladorNavMesh.HemosLLegado())
        {
            siguienteWayPoint=(siguienteWayPoint+1)%wayPoints.Length;
            actializarWayPointDestino();
        }
    }
    private void OnEnable()
    {
        actializarWayPointDestino();
       
    }
    void actializarWayPointDestino()
    {
        controladorNavMesh.ActualizarDestinoNavMesh(wayPoints[siguienteWayPoint].position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && enabled)
        {

            MaquinaEstados.activarEstado(MaquinaEstados.estadoAlerta);
        }
    }
}
