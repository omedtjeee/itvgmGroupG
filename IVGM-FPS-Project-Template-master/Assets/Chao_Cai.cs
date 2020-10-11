using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao_Cai : MonoBehaviour
{



    public GameObject Floor;
    public Transform Jogador;


    void OnTriggerEnter(Collider theCollider)
    {
        if (theCollider.CompareTag("Player")) //If player on top of the tile
        {
            //Floor.GetComponent<Renderer>().material.color = Color.red;
            Floor.SetActive(false);
            //Floor.GetComponent<Animation>().CrossFade("Falling");
             
        }
    }
   
}
