using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getKey : MonoBehaviour
{

    public AutomticOpening automaticDoor;
    Pickup m_Pickup;
    // Start is called before the first frame update
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup,getKey>(m_Pickup,this,gameObject);

        //subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController other) {
        if(automaticDoor.key1 == false) {
            automaticDoor.key1 = true;
            Destroy(gameObject);
        }
        else {
            automaticDoor.key2 = true;
            Destroy(gameObject);
        }
       

        
       
    }
}
