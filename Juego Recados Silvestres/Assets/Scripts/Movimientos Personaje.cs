using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosPersonaje : MonoBehaviour
{
    public CharacterController Controlador;
    public float Velocidad = 15f;
    public float VelocidadCorrer = 80f; // Velocidad de correr
    public float SensibilidadRaton = 30f;
    private bool corriendo = false;
    float rotacionY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obtener entrada del teclado
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calcular el movimiento del personaje
        Vector3 mover = transform.right * x + transform.forward * z;

        // Aplicar movimiento al personaje
        float velocidadActual = corriendo ? VelocidadCorrer : Velocidad;
        Controlador.Move(mover * velocidadActual * Time.deltaTime);

        // Obtener la rotación del ratón
        float rotacionX = Input.GetAxis("Mouse X") * SensibilidadRaton;

        // Rotar el personaje horizontalmente
        transform.Rotate(Vector3.up * rotacionX);

        // Obtener la rotación vertical del ratón
        rotacionY -= Input.GetAxis("Mouse Y") * SensibilidadRaton;

        // Limitar la rotación vertical
        rotacionY = Mathf.Clamp(rotacionY, -80f, 80f);

        // Aplicar rotación vertical a la cámara
        Camera.main.transform.localRotation = Quaternion.Euler(rotacionY, 0f, 0f);

        // Comprobar si el jugador presiona la tecla Shift para correr
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            corriendo = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            corriendo = false;
        }
    }
}