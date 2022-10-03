using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    Vector3 direccion;
    public float velocidad = 10;
    
    CharacterController jugador;
    void Start()
    {
        jugador = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")).normalized;

        jugador.Move(direccion * velocidad * Time.deltaTime);
    }
}
