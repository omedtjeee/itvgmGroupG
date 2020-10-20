using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveScript : MonoBehaviour
{
    public GameObject ValveToRotate;
    public int ValveValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Trigger Detected");
        if (other.name=="Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Rotate());
            }
        }
    }
    public IEnumerator Rotate()
    {
        Debug.Log("Started");
        for (int i = 0; i < 100; i++)
        {
            ValveToRotate.transform.Rotate(new Vector3(0, 1, 0));
            yield return new WaitForSeconds(.05f);
        }
        Debug.Log("Ended");
       
        if(PlayerPrefs.GetInt("Valve"+ValveValue,0)==0)
        {
            PlayerPrefs.SetInt("Valve" + ValveValue, 1);
            Debug.Log("Value Changed -> Valve"+ValveValue+" = 1");
            GetComponent<ObjectivePickupItem>().OnPickup();
        }
    }
}
