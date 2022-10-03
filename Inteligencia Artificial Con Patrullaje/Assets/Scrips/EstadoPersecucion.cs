using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecucion : MonoBehaviour
{
    ControladorMaquinaEstados maquinaEstados;
    ControladorNavMesh controladorNav;
    ControladorVision controladorVision;    
    private void Awake()
    {
        maquinaEstados = GetComponent<ControladorMaquinaEstados>();
        controladorNav = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();  
    }

    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if(!controladorVision.PuedeVerAljugador(out Hit,true))
        {
            maquinaEstados.activarEstado(maquinaEstados.estadoAlerta);
            return;
        }
        controladorNav.ActualizarDestinoNavMesh();
    }
}
