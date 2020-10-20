using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public static DoorHandler Instance { get; private set; }

    private bool allCollected = false;
    private bool openDoor = false;

    private float doorHeight = 3.0f;

    private bool blue = false, red = false, green = false;

    public Material BlueLight, RedLight, GreenLight, SecretLight;

    List<LightController> lights;

    public void OnTriggerEnter(Collider other)
    {
        PlayerCharacterController pickingPlayer = other.GetComponent<PlayerCharacterController>();

        if (pickingPlayer != null)
        {
            if (allCollected)
            {
                openDoor = true;
            }
        }
    }

    void Update()
    {
        if (openDoor && doorHeight > 0)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime);
            doorHeight -= Time.deltaTime;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        lights = new List<LightController>();
    }

    private void TurnOn (string lightName, Color m)
    {
        foreach (LightController l in lights)
        {
            if (l.GetName() == lightName)
                l.LightOn(m);
        }
    }

    public void RegisterLight(LightController light)
    {
        lights.Add(light);
    }

    public void CheckAllCollected()
    {
        if (blue && red && green)
            allCollected = true;
    }

    public void BlueCollected()
    {
        blue = true;
        CheckAllCollected();
        TurnOn("Blue", Color.blue);
    }

    public void RedCollected()
    {
        red = true;
        CheckAllCollected();
        TurnOn("Red", Color.red);
    }

    public void GreenCollected()
    {
        green = true;
        CheckAllCollected();
        TurnOn("Green", Color.green);
    }

    public void SecretCollected(int sIndex)
    {
        TurnOn(String.Format("Secret" + sIndex), Color.yellow);
        Debug.Log(String.Format("Secret" + sIndex));
    }
}
