using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPickup : MonoBehaviour
{
    private int sn;
    public DoorHandler dh;
    // Start is called before the first frame update
    void Start()
    {
        dh = GameObject.FindObjectOfType(typeof(DoorHandler)) as DoorHandler;
        sn = (int)name[0] - 47;
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerCharacterController p = other.GetComponent<PlayerCharacterController>();

        if (p != null)
        {
            dh.SecretCollected(sn);

            Destroy(gameObject);
        }
    }
}
