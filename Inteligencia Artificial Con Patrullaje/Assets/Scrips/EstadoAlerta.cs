using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAlerta : MonoBehaviour
{
    ControladorMaquinaEstados maquinaEstados;
    ControladorNavMesh controladorNavMesh;
    ControladorVision controladorVision;

    public float velocidadBusqueda = 120f;
    public float duracionBusqueda = 4f;
    float tiempoBuscando;

    private void Awake()
    {
        maquinaEstados = GetComponent<ControladorMaquinaEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision  = GetComponent<ControladorVision>();
    }
    private void OnEnable()
    {
        controladorNavMesh.DetenerNavMesh();
        tiempoBuscando = 0;
    }
    private void Update()
    {
        RaycastHit hit;
        if (controladorVision.PuedeVerAljugador(out hit))
        {
            controladorNavMesh.objetivo = hit.transform;
            maquinaEstados.activarEstado(maquinaEstados.estadoPersecucion);
            return;
        }
        transform.Rotate(0f,velocidadBusqueda*Time.deltaTime,0f);
        tiempoBuscando+=Time.deltaTime;
        if (tiempoBuscando>=duracionBusqueda)
        {
            maquinaEstados.activarEstado(maquinaEstados.estadoPatrulla);
            return;
        }
    }
}
