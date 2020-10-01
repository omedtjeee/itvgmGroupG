using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    private Light myLight;
    public float maxIntensity = 50f;
    public float minIntensity = 0f;
    public float pulseSpeed = 25f;
    private float targetIntensity = 50f;
    private float currentIntensity;


    void Start()
    {
        myLight = GetComponent<Light>();
    }
    void Update()
    {
        currentIntensity = Mathf.MoveTowards(myLight.intensity, targetIntensity, Time.deltaTime * pulseSpeed);
        if (currentIntensity >= maxIntensity) // grow towards the max intensity
        {
            currentIntensity = maxIntensity;
            targetIntensity = minIntensity;
        }
        else if (currentIntensity <= minIntensity) // grow towards the min intensity
        {
            currentIntensity = minIntensity;
            targetIntensity = maxIntensity;
        }
        myLight.intensity = currentIntensity; //update light intensity
    }
}
