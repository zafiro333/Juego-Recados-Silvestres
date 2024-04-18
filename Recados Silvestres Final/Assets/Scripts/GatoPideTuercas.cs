using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatoPideTuercas : MonoBehaviour
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
        // Si se presiona la tecla E y el mensaje está activo, entregar las tuercas
        if (mensajeText.enabled && Input.GetKeyDown(KeyCode.E) && !misionCompletada)
        {
            if (player.GetComponent<AlmacenTuercas>().cantTuercas >= 2)
            {
                player.GetComponent<AlmacenTuercas>().cantTuercas -= 2;
                mensajeText.text = "¡Muchas gracias!";
                misionCompletada = true; // Marcar la misión como completada
            }
            else
            {
                mensajeText.text = "¡No son suficientes tuercas!";
            }
        }
    }

    void MostrarMensaje()
    {
        mensajeText.enabled = true; // Activar el texto del NPC
        mensajeText.text = "¡Quiero 2 sets de tuercas,están cerca de la parada de autobus!";
    }

    void OcultarMensaje()
    {
        mensajeText.enabled = false; // Desactivar el texto del NPC
    }
}
