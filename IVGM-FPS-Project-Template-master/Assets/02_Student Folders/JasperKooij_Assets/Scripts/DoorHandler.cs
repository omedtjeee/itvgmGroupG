using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public static DoorHandler Instance { get; private set; }

    private bool allCollected = false;
    private bool openDoor = false;

    private float doorHeight = 3.0f;
    
    public void OnTriggerEnter(Collider other)
    {
        PlayerCharacterController pickingPlayer = other.GetComponent<PlayerCharacterController>();

        if (pickingPlayer != null)
        {
            if (allCollected)
            {
                openDoor = true;
            }
        }
    }

    void Update()
    {
        if (openDoor && doorHeight > 0)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime);
            doorHeight -= Time.deltaTime;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AllCollected()
    {
        allCollected = true;
    }


        

}
