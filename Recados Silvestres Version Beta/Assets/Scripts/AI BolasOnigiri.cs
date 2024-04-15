using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBolasOnigiri : MonoBehaviour
{
    public Transform Objetivo;
    public float Velocidad;
    public NavMeshAgent IA;

    // Update is called once per frame
    void Update()
    {
        IA.speed = Velocidad;
        IA.SetDestination(Objetivo.position);
    }
}