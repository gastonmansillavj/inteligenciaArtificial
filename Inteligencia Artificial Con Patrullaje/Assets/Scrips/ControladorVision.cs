using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVision : MonoBehaviour
{
    public Transform ojos;
    public float RangoVision = 100f;
    public Vector3 offset = new Vector3(0f,0.5f,0f);
    private ControladorNavMesh controladorNavMesh;
    private void Awake()
    {
        controladorNavMesh = GetComponent<ControladorNavMesh>(); 
    }
    public bool PuedeVerAljugador (out RaycastHit hit, bool mirarHaciaElJugador=false)
    {
        Vector3 vectorDireccion;
        if (mirarHaciaElJugador)
        {
            vectorDireccion = (controladorNavMesh.objetivo.position+offset)-ojos.position;
        }
        else
        {
            vectorDireccion = ojos.forward;
        }
        
        return Physics.Raycast(ojos.position,ojos.forward,out hit,RangoVision)&& hit.collider.CompareTag("Player");
    }

}
