using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBolasPastel : MonoBehaviour
{
    public Transform Objetivo;
    public float Velocidad;
    public float DistanciaActivacion; // Distancia mínima para activar el seguimiento
    public float DistanciaDesactivacion; // Distancia máxima para detener el seguimiento
    public NavMeshAgent IA;
    private bool estaSiguiendo = false;

    // Update is called once per frame
    void Update()
    {
        // Calcula la distancia entre el jugador y este enemigo
        float distanciaAlObjetivo = Vector3.Distance(Objetivo.position, transform.position);
        
        // Si el jugador está dentro del rango de activación y no estamos siguiendo, activa el seguimiento
        if (distanciaAlObjetivo <= DistanciaActivacion && !estaSiguiendo)
        {
            estaSiguiendo = true;
        }

        // Si estamos siguiendo, actualiza la velocidad y destino del NavMeshAgent
        if (estaSiguiendo)
        {
            IA.speed = Velocidad;
            IA.SetDestination(Objetivo.position);

            // Verifica si el jugador está fuera del rango de desactivación, si es así, deja de seguir
            if (distanciaAlObjetivo > DistanciaDesactivacion)
            {
                estaSiguiendo = false;
            }
        }
    }
}
