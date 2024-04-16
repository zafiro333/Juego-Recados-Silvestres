using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CodigoSalud : MonoBehaviour
{
    public float Salud = 100;
    public float SaludMaxima = 100;

    public Image BarraSalud;
    public Text TextoSalud;


    public GameObject Muerto;



    void Update()
    {
        ActualizarInterfaz();
    }

    public void RecibirDano(float dano)
    {
        Salud -= dano;

        if(Salud <= 0)
        {
            Instantiate(Muerto);
            Destroy(gameObject);
        }
    }


    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = Salud/SaludMaxima;
        TextoSalud.text = "Vida " + Salud.ToString("f0");
    }
}
