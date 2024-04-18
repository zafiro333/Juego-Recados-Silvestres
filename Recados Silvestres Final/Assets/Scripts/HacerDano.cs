using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerDano : MonoBehaviour
{
    public float CantidadDano;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.GetComponent<CodigoSalud>())
        {
            other.GetComponent<CodigoSalud>().RecibirDano(CantidadDano);

        }
    }
}
