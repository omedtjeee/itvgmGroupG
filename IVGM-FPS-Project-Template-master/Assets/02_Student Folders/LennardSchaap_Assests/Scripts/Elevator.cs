using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
  public enum CurrentFloor {floor0f = 0, floor1f = 1, floor2f = 2, floor3f = 3};
  public CurrentFloor currentfloor;

  public enum States {moving, still};
  public States state;

  public enum Actions {moveto0f = 0, moveto1f = 1, moveto2f = 2, moveto3f = 3};
  public Actions action;

  public bool move = false;
  public bool playerInside = false;

  GameObject elevator;
  GameObject door0f;
  GameObject door1f;
  GameObject door2f;
  GameObject door3f;

  private Vector3 startPos;
  private Vector3 endPos;

  private int floorDistance = 11;
  private int distance = 0;
  private float floorLerpTime = 5;
  private float lerpTime = 0;
  private float currentLerpTime = 0;
  public bool arrived = false;

  public AudioSource travelaudio;
  public AudioSource arrivedaudio;

  void Move() {

    currentLerpTime += Time.deltaTime;

    if (currentLerpTime >= lerpTime)
    {
      currentLerpTime = lerpTime;
    }

    float Perc = currentLerpTime / lerpTime;

    elevator.transform.position = Vector3.Lerp(startPos, endPos, Perc);
  }

  // Start is called before the first frame update
  void Start()
  {
    elevator = GameObject.Find("Elevator");
    door0f = GameObject.Find("Automatic_Elevator_Door_0F");
    door1f = GameObject.Find("Automatic_Elevator_Door_1F");
    door2f = GameObject.Find("Automatic_Elevator_Door_2F");
    door3f = GameObject.Find("Automatic_Elevator_Door_3F");
    state = States.still;
  }

  // Update is called once per frame
  void Update()
  {
    if (state == States.still && move)
    {
      // Setting up for the Move function.
      state = States.moving;
      Debug.Log((int)action);
      distance = ((int)action - (int)currentfloor);
      distance *= floorDistance;
      Debug.Log("Distance: " + distance);
      lerpTime = (float)Mathf.Abs(((int)action - (int)currentfloor));
      lerpTime *= floorLerpTime;
      Debug.Log("lerpTime: " + lerpTime);
      if (distance == 0)
      {
        state = States.still;
        move = false;
        Open();
        return;
      }
      travelaudio.Play();
      Debug.Log("Play");
      Close();
      startPos = elevator.transform.position;
      endPos = elevator.transform.position + Vector3.up * distance;
      distance /= floorDistance;
      currentfloor = (CurrentFloor)((int)currentfloor + (int)distance);
    }
    else if (state == States.moving)
    {
      Move();
    }
    if (currentLerpTime >= lerpTime && (state == States.moving))
    {
      Debug.Log("arrived 1");
      currentLerpTime = 0;
      state = States.still;
      arrived = true;
      arrivedaudio.Play();
    }
    if (arrived && playerInside) {
      Debug.Log("arrived opening door");
      Open();
    }
    move = false;
    arrived = false;
  }

  void OnTriggerEnter(Collider coll)
  {
    if (coll.tag == "Player") {
      Debug.Log("Player enter");
      Close();
      coll.transform.parent = transform;
      playerInside = true;
    }
  }

  void OnTriggerExit(Collider coll)
  {
    if (coll.tag == "Player") {
      Debug.Log("Player exit");
      Close();
      coll.transform.parent = null;
      playerInside = false;
    }
  }

  void Close()
  {
    switch(currentfloor)
    {
      case CurrentFloor.floor0f:
        door0f.GetComponent<AutomaticElevatorDoor>().close = true;
        break;
      case CurrentFloor.floor1f:
        door1f.GetComponent<AutomaticElevatorDoor>().close = true;
        break;
      case CurrentFloor.floor2f:
        door2f.GetComponent<AutomaticElevatorDoor>().close = true;
        break;
      case CurrentFloor.floor3f:
        door3f.GetComponent<AutomaticElevatorDoor>().close = true;
        break;
    }
  }

  void Open()
  {
    switch(currentfloor)
    {
      case CurrentFloor.floor0f:
        Debug.Log("0");
        door0f.GetComponent<AutomaticElevatorDoor>().open = true;
        break;
      case CurrentFloor.floor1f:
        Debug.Log("1");
        door1f.GetComponent<AutomaticElevatorDoor>().open = true;
        break;
      case CurrentFloor.floor2f:
        Debug.Log("2");
        door2f.GetComponent<AutomaticElevatorDoor>().open = true;
        break;
      case CurrentFloor.floor3f:
        Debug.Log("3");
        door3f.GetComponent<AutomaticElevatorDoor>().open = true;
        break;
    }
  }
}
