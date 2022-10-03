using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMaquinaEstados : MonoBehaviour
{
    public MonoBehaviour estadoPatrulla;
    public MonoBehaviour estadoAlerta;
    public MonoBehaviour estadoPersecucion;
    public MonoBehaviour estadoinicial;
    MonoBehaviour estadoActual;

   
    // Start is called before the first frame update
    void Start()
    {
        activarEstado(estadoinicial);
    }

    public void activarEstado (MonoBehaviour nuevoEstado){
        if (estadoActual!=null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled=true;

    }
}
