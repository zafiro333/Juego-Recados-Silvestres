using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelDatos : MonoBehaviour
{
    GameObject player;
    bool puedeAgarrar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(puedeAgarrar)
        {
             if(Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<AlmacenPastel>().cantPasteles += 1;
            Destroy(gameObject);
        }
        }
    }

   private void OnTriggerEnter(Collider other)
   {
    if(other.tag =="Player")
    {
       puedeAgarrar = true;
    }
   }

   private void OnTriggerExit(Collider other)
   {
    if(other.tag =="Player")
    {
       puedeAgarrar = false;
    }
   }
}
