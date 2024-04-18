using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConejoPideHuevo : MonoBehaviour
{
    GameObject player;
    public Text mensajeText;
    bool misionCompletada = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        OcultarMensaje(); // Ocultar el mensaje al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Mostrar el mensaje si la misión no está completada
            if (!misionCompletada)
            {
                MostrarMensaje();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            OcultarMensaje();
        }
    }

    private void Update()
    {
        // Si se presiona la tecla E y el mensaje está activo, entregar los huevos
        if (mensajeText.enabled && Input.GetKeyDown(KeyCode.E) && !misionCompletada)
        {
            if (player.GetComponent<Almacen>().cantHuevos >= 2)
            {
                player.GetComponent<Almacen>().cantHuevos -= 2;
                mensajeText.text = "¡Muchas gracias!";
                misionCompletada = true; // Marcar la misión como completada
            }
            else
            {
                mensajeText.text = "Te faltan huevos...necesito 2";
            }
        }
    }

    void MostrarMensaje()
    {
        mensajeText.enabled = true; // Activar el texto del NPC
        mensajeText.text = "Quiero 2 huevos porfi, están en una cueva...";
    }

    void OcultarMensaje()
    {
        mensajeText.enabled = false; // Desactivar el texto del NPC
    }
}
