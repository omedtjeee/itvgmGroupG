using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeDamage : MonoBehaviour
{
    //public Health health;
    public GameObject spikes;
    public GameObject lava;
    float damageTime = 1.0f;
    float currentDamageTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerStay(Collider other) {
        
        Health playerhealth = other.GetComponent<Health>();
        currentDamageTime += Time.deltaTime;
        if (currentDamageTime > damageTime) {
            playerhealth.TakeDamage(5, lava);
            currentDamageTime = 0.0f;
        }    
    }

    void OnTriggerEnter(Collider other) {
        Health playerhealth = other.GetComponent<Health>();
        playerhealth.TakeDamage(50, spikes);
    }
}
