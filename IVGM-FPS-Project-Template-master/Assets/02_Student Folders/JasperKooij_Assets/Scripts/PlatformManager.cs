using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance { get; private set; }

    List<PlatformController> platforms;

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

        platforms = new List<PlatformController>();
    }

    public void RegisterPlatform(PlatformController platform)
    {
        platforms.Add(platform);
    }

    private enum Platform
    {
        Blue,
        Red,
        Green
    };

    // Start is called before the first frame update
    void Start()
    {
        foreach (PlatformController p in platforms)
        {
            p.HidePlatform();
        }
    }

    public void ShowPlatforms(int colorIndex)
    {
        string color = ((Platform)colorIndex).ToString();

        foreach (PlatformController p in platforms)
        {
            if (p.GetColor() == color)
                p.ShowPlatform();
            else
                p.HidePlatform();
        }
    }

    public void HidePlatforms()
    {
        foreach (PlatformController p in platforms)
        {
            p.HidePlatform();
        }
    }
}
