using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private bool onoff;
    // Start is called before the first frame update
    void Start()
    {
        onoff = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            onoff = !onoff;
            GetComponent<Renderer>().enabled = onoff;
        }
    }
}
