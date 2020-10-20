using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private string Tag;
    
    void Start()
    {
        PlatformManager.Instance.RegisterPlatform(this);
        Tag = gameObject.tag;
    }

    public string GetColor()
    {
        return Tag;
    }

    public void ShowPlatform()
    {
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }

    public void HidePlatform()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
