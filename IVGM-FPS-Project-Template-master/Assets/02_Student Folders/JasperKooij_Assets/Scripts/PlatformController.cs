using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private bool onoff;
    private int color = 0;

    private enum Platform
    {
        White,
        Green,
        Blue,
        Red
    };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            color = 0;
            ShowPlatform(color);
        }
        if(Input.GetMouseButtonDown(0))
        {
            color = color % 3 + 1;
            ShowPlatform(color);
        }
    }

    void ShowPlatform(int colorIndex)
    {
        Renderer r = GetComponent<Renderer>();
        Collider c = GetComponent<Collider>();

        switch(colorIndex)
        {
            case 0:
                r.enabled = false;
                c.enabled = false;
                break;
            default:
                if (gameObject.CompareTag( ((Platform)colorIndex).ToString()) )
                {
                    r.enabled = true;
                    c.enabled = true;
                }
                else
                {
                    r.enabled = false;
                    c.enabled = false;
                }
                break;
        }
    }
}
