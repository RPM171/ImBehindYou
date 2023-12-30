using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    public Transform objetivo; // Referencia al transform del personaje

    public Vector3 offset = new Vector3(0f, 2f, -5f); // Ajusta el desplazamiento de la cámara

    void LateUpdate()
    {
        if (objetivo == null)
            return;

        // Establecer la posición de la cámara a la posición del personaje + el offset
        transform.position = objetivo.position + offset;

        // Apuntar la cámara hacia el personaje
        transform.LookAt(objetivo);
    }
}


