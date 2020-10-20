using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonManager : MonoBehaviour
{
    public GameObject toDisable;
    public bool disabled = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (disabled)
      {
        toDisable.SetActive(false);
      }
      else {
        toDisable.SetActive(true);
      }
    }
}
