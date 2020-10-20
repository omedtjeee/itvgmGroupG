using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public int a, b;
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Valve1", 0);
        PlayerPrefs.SetInt("Valve2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        a = PlayerPrefs.GetInt("Valve1", 0);
        b = PlayerPrefs.GetInt("Valve2", 0);
        if (a == 1&& b == 1)
        {
            g.GetComponent<Objective>().enabled = true;
            g.GetComponent<CompassElement>().enabled = true;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
           // Destroy(gameObject);
        }
    }
}
