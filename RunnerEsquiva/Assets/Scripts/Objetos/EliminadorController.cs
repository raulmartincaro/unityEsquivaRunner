using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminadorController : MonoBehaviour
{
    
   private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag != "Personaje")
        {
       
        Destroy(collision.gameObject);

        }
    }

}
