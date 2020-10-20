using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private string lightName;

    void Start()
    {
        DoorHandler.Instance.RegisterLight(this);
        lightName = gameObject.name;
    }

    public void LightOn(Color c)
    {
        GetComponent<Renderer>().material.color = c;
    }

    public string GetName()
    {
        return lightName;
    }
}
