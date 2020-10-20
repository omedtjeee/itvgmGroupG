using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash_light : MonoBehaviour
{
    public GameObject lightSource;
    public bool isOn = false;
    public bool failSafe = false;
    
 

    void Start()
    {
        lightSource.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("FKey"))
        {
            if (isOn == false && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(true);
                isOn = true;
                StartCoroutine(FailSafe());
            }
            if (isOn == true && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(false);
                isOn = false;
                StartCoroutine(FailSafe());
            }
        }
        
    }
    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failSafe = false;
    }


   
}
