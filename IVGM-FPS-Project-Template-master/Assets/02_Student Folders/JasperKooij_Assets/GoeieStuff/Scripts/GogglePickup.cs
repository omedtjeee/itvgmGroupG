using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogglePickup : MonoBehaviour
{
    public GoggleSelection gs;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameObject.FindObjectOfType(typeof(GoggleSelection)) as GoggleSelection;
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerCharacterController pickingPlayer = other.GetComponent<PlayerCharacterController>();

        if (pickingPlayer != null)
        {
            gs.Collected();
            
            Destroy(gameObject);
        }

    }
}
