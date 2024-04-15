using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 7f;
    public float runSpeed = 14f; // Doble de la velocidad de caminar
    public float rotationSpeed = 250f;

    public Animator animator;

    private float x, y;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Determina la velocidad de movimiento según si se presiona Shift o no
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // Aplica la rotación y el movimiento del personaje
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * currentSpeed);

        // Actualiza los parámetros del Animator
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }
}