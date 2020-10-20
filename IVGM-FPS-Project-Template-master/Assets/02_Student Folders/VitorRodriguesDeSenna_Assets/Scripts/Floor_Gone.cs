using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Gone : MonoBehaviour
{

    public GameObject Floor;
   // public Transform Jogador;

    void OnTriggerEnter(Collider theCollider)
    {
        if (theCollider.CompareTag("Player"))
        {

            Floor.SetActive(false);
        }
    }
}

