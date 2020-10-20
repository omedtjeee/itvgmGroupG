using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretPickup : MonoBehaviour
{
    private int sn;
    public DoorHandler dh;
    public Sprite s;

    private GameObject S;

    // Start is called before the first frame update
    void Start()
    {
        dh = GameObject.FindObjectOfType(typeof(DoorHandler)) as DoorHandler;
        sn = (int)name[0] - 47;
        S = GameObject.FindGameObjectWithTag("Secret!");
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerCharacterController p = other.GetComponent<PlayerCharacterController>();

        if (p != null)
        {
            dh.SecretCollected(sn);
            S.gameObject.transform.GetChild(sn).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
