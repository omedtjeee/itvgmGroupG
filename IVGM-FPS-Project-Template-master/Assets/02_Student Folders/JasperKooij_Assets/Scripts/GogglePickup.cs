using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogglePickup : MonoBehaviour
{

    Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);

    }
}
