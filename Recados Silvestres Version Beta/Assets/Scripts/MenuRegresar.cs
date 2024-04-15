using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuRegresar : MonoBehaviour
{
   public void Volver(){
    SceneManager.LoadScene("Juego");
   }

   public void Salir(){
      Debug.Log("Salir...");
      Application.Quit();
   }
        
    
}
