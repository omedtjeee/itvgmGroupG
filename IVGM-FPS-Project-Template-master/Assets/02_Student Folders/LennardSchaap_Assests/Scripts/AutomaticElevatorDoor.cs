using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticElevatorDoor : MonoBehaviour
{

  public enum ElevatorDoors {elevatorDoor0f = 0, elevatorDoor1f = 1,
                             elevatorDoor2f = 2, elevatorDoor3f = 3};
  public ElevatorDoors elevatordoor;

  public bool open = false;
  public bool close = false;
  public bool isOpen = false;
  bool opening = false;
  bool closing = false;
  float speed = 5f;
  float timer;
  float timerLength = 1f;

  Vector3 door1DefaultPosition = new Vector3(0,0,0);
  Vector3 door2DefaultPosition = new Vector3(0,0,-3);

  public Transform door1;
  public Transform door2;

  Collider triggerZone;
  GameObject elevator;

  // Start is called before the first frame update
  void Start()
  {
    elevator = GameObject.Find("Elevator");
    triggerZone = GetComponent<Collider>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!isOpen && !opening && open)
    {
      if ((int)elevator.gameObject.GetComponent<Elevator>().currentfloor ==
          (int)elevatordoor)
        {
          opening = true;
          timer = timerLength;
        }
    }
    else if (!opening && isOpen && close) {
      closing = true;
      timer = timerLength;
    }

    if (opening && timer > 0f)
    {
      door1.Translate(Vector3.forward * Time.deltaTime * speed);
      door2.Translate(-Vector3.forward * Time.deltaTime * speed);
      timer -= Time.deltaTime;
    }
    else if (opening && timer <= 0f)
    {
      opening = false;
      timer = timerLength;
      isOpen = true;
    }
    if (closing && timer > 0f)
    {
      door1.Translate(-Vector3.forward * Time.deltaTime * speed);
      door2.Translate(Vector3.forward * Time.deltaTime * speed);
      timer -= Time.deltaTime;
    }
    else if (closing && timer <= 0f)
    {
      closing = false;
      timer = timerLength;
      isOpen = false;
      door1.localPosition = door1DefaultPosition;
      door2.localPosition = door2DefaultPosition;
    }
    open = false;
    close = false;
  }
}
