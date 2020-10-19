using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public static PlatformController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private enum Platform
    {
        White,
        Blue,
        Red,
        Green
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
        //if(Input.GetMouseButtonDown(1))
        //{
        //    color = 0;
        //    ShowPlatform(color);
        //}
        // if(Input.GetMouseButtonDown(0))
        //{
        //    color = color % 3 + 1;
        //    ShowPlatform(color);
        // }
    }

    public void ShowPlatform(int colorIndex)
    {
        
        Renderer r = GetComponent<Renderer>();
        Collider c = GetComponent<Collider>();

        //switch(colorIndex)
        //{
        //    case 0:
        //        r.enabled = false;
        //        c.enabled = false;
        //        break;
        //    default:
        //        if (gameObject.CompareTag( ((Platform)colorIndex).ToString()) )
        //        {
        //            r.enabled = true;
        //            c.enabled = true;
        //        }
        //        else
        //        {
        //            r.enabled = false;
        //            c.enabled = false;
        //        }
        //        break;d
        //}
    }
}
