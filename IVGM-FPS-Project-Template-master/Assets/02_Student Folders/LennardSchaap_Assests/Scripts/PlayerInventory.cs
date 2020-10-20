using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  public bool hasRedKeycard, hasBlueKeycard, hasGreenKeycard;

  // Start is called before the first frame update
  void Start()
  {
    hasRedKeycard = false;
    hasBlueKeycard = false;
    hasGreenKeycard = false;
  }
}
