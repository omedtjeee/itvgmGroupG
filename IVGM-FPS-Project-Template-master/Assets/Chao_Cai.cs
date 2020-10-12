using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao_Cai : MonoBehaviour
{



    public Transform Floor;
    Collider triggerZone;
    float speed = 5f;
   // bool onTop = false;
    bool falling = false;
    float timer;
    float timerLenght = 1f;
    // public Transform Player;

    void Start()
    {
        triggerZone = GetComponent<Collider>();
    }

    void Update()
    {
        if (falling && timer > 0f)
        {
            Floor.Translate(Vector3.forward * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
        else if (falling && timer <= 0f)
        {
            falling = false;
            timer = timerLenght;

        }

        void OnTriggerEnter(Collider other)
        {
            
               // onTop = true;
                timer = timerLenght;
                falling = true;
            
        }
    }
}

 

    
