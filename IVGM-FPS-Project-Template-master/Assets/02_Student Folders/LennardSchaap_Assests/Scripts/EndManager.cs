using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
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
    if(toDisable != null)
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
}
