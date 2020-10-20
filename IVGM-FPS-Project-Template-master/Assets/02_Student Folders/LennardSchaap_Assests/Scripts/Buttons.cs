using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
  public enum Button {elevatorButtonIn0F, elevatorButtonIn1F,
                      elevatorButtonIn2F, elevatorButtonIn3F,
                      elevatorButtonOut0F, elevatorButtonOut1F,
                      elevatorButtonOut2F, elevatorButtonOut3F,};

  public Button whatButton;
  public bool pressed = false;

  public Transform button;

  Vector3 defaultPosition = new Vector3(0,0,0);

  float speed = 2f;
  bool isOperating = false;
  bool pressing = false;
  bool returning = false;
  float timer;
  float timerLength = 0.04f;

  GameObject door0f;
  GameObject door1f;
  GameObject door2f;
  GameObject door3f;
  GameObject elevator;

  void Start()
  {
    elevator = GameObject.Find("Elevator");
    door0f = GameObject.Find("Automatic_Elevator_Door_0F");
    door1f = GameObject.Find("Automatic_Elevator_Door_1F");
    door2f = GameObject.Find("Automatic_Elevator_Door_2F");
    door3f = GameObject.Find("Automatic_Elevator_Door_3F");

    pressed = false;
  }

  void Update()
  {
    if (!isOperating && pressed)
    {
      isOperating = true;
      pressing = true;
      timer = timerLength;
    }
    if (pressing && timer > 0f)
    {
      button.Translate(Vector3.down * Time.deltaTime * speed);
      timer -= Time.deltaTime;
    }
    else if (pressing && timer <= 0f)
    {
      pressing = false;
      timer = timerLength;
      returning = true;
    }
    if (returning && timer > 0f)
    {
      button.Translate(-Vector3.down * Time.deltaTime * speed);
      timer -= Time.deltaTime;
    }
    else if (returning && timer <= 0f)
    {
      returning = false;
      timer = timerLength;
      isOperating = false;
      button.localPosition = defaultPosition;
    }
    if (pressed)
    {
      switch(whatButton)
      {
        case Button.elevatorButtonOut0F:
          if (!door0f.GetComponent<AutomaticElevatorDoor>().isOpen)
            {
              door0f.GetComponent<AutomaticElevatorDoor>().open = true;
            }
          else
            {
              door0f.GetComponent<AutomaticElevatorDoor>().close = true;
            }
          break;
        case Button.elevatorButtonOut1F:
          if (!door1f.GetComponent<AutomaticElevatorDoor>().isOpen)
            {
              door1f.GetComponent<AutomaticElevatorDoor>().open = true;
            }
          else
            {
              door1f.GetComponent<AutomaticElevatorDoor>().close = true;
            }
          break;
        case Button.elevatorButtonOut2F:
          if (!door2f.GetComponent<AutomaticElevatorDoor>().isOpen)
            {
              door2f.GetComponent<AutomaticElevatorDoor>().open = true;
            }
          else
            {
              door2f.GetComponent<AutomaticElevatorDoor>().close = true;
            }
          break;
        case Button.elevatorButtonOut3F:
          if (!door3f.GetComponent<AutomaticElevatorDoor>().isOpen)
            {
              door3f.GetComponent<AutomaticElevatorDoor>().open = true;
            }
          else
            {
              door3f.GetComponent<AutomaticElevatorDoor>().close = true;
            }
          break;
        case Button.elevatorButtonIn0F:
          elevator.GetComponent<Elevator>().move = true;
          elevator.GetComponent<Elevator>().action = Elevator.Actions.moveto0f;
          break;
        case Button.elevatorButtonIn1F:
          elevator.GetComponent<Elevator>().move = true;
          elevator.GetComponent<Elevator>().action = Elevator.Actions.moveto1f;
          break;
        case Button.elevatorButtonIn2F:
          elevator.GetComponent<Elevator>().move = true;
          elevator.GetComponent<Elevator>().action = Elevator.Actions.moveto2f;
          break;
        case Button.elevatorButtonIn3F:
          elevator.GetComponent<Elevator>().move = true;
          elevator.GetComponent<Elevator>().action = Elevator.Actions.moveto3f;
          break;
      }
    }
    pressed = false;
  }
}
