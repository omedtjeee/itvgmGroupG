using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basico : MonoBehaviour
{
    public Transform Jogador;
    


    
    void OnTriggerEnter(Collider theCollider)
    {
        if (theCollider.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = Color.grey;
        }


    }

  
}
