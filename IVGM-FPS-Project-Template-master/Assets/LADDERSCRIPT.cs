using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LADDERSCRIPT : MonoBehaviour
{
    public GameObject playerOBJ;
    public bool canClimb = false;
    public float speed = 1;

    void OnTriggerEnter(Collider coll)
    {
        canClimb = true;
        playerOBJ = coll.gameObject;
        if (coll.gameObject.tag == "Player")
        {
            canClimb = true;
            playerOBJ = coll.gameObject;
        }
    }

    void OnTriggerExit(Collider coll2)
    {
        canClimb = false;
        playerOBJ = null;
        if (coll2.gameObject.tag == "Player")
        {
            canClimb = false;
            playerOBJ = null;
        }
        //gameObject.GetComponent<CharacterController>().Move(new Vector3(0, .5f, 0))
    }
    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Trigger Detected");
        if (other.name == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                other.GetComponent<CharacterController>().Move(new Vector3(0, 1, 0));
            }
            
        }
    }
    void Update()
    {
        if (canClimb)
        {
            if (Input.GetKey(KeyCode.F))
            {
                playerOBJ.transform.Translate(new Vector3(0, 10, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerOBJ.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        }
    }
}
