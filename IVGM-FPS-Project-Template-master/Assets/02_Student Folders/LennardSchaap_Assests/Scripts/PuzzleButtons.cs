using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtons : MonoBehaviour
{
  public enum PuzzleButton {puzzle1button1, puzzle1button2,
                            puzzle1button3, puzzle1button4,
                            puzzle2button1, puzzle2button2,
                            puzzle2button3, puzzle2button4,
                            puzzle2button5, puzzle2button6,
                            puzzle2button7, puzzle2button8,
                            puzzle2button9
                            };

  public PuzzleButton whatPuzzleButton;

  public enum OnOff {on = 0, off = 1};

  public OnOff status;

  public Transform button;

  public bool pressed = false;
  public bool activated = false; ////
  public bool ready = false;

  Vector3 defaultPosition = new Vector3(0,0,0);

  float speed = 1f;
  bool isOperating = false;
  bool pressing = false;
  bool returning = false;

  float timer;
  float timerLength = 0.01f;

  GameObject puzzle1button1;
  GameObject puzzle1button2;
  GameObject puzzle1button3;
  GameObject puzzle1button4;

  GameObject puzzle2button1;
  GameObject puzzle2button2;
  GameObject puzzle2button3;
  GameObject puzzle2button4;
  GameObject puzzle2button5;
  GameObject puzzle2button6;
  GameObject puzzle2button7;
  GameObject puzzle2button8;
  GameObject puzzle2button9;

  GameObject manager;

  public Material[] material;
  Renderer rend;

  void Start()
  {
    puzzle1button1 = GameObject.Find("Puzzle1Button1");
    puzzle1button2 = GameObject.Find("Puzzle1Button2");
    puzzle1button3 = GameObject.Find("Puzzle1Button3");
    puzzle1button4 = GameObject.Find("Puzzle1Button4");

    puzzle2button1 = GameObject.Find("Puzzle2Button1");
    puzzle2button2 = GameObject.Find("Puzzle2Button2");
    puzzle2button3 = GameObject.Find("Puzzle2Button3");
    puzzle2button4 = GameObject.Find("Puzzle2Button4");
    puzzle2button5 = GameObject.Find("Puzzle2Button5");
    puzzle2button6 = GameObject.Find("Puzzle2Button6");
    puzzle2button7 = GameObject.Find("Puzzle2Button7");
    puzzle2button8 = GameObject.Find("Puzzle2Button8");
    puzzle2button9 = GameObject.Find("Puzzle2Button9");

    manager = GameObject.Find("PuzzleManager");

    rend = button.GetComponent<Renderer>();
    rend.enabled = true;
    rend.sharedMaterial = material[0];
  }

  void Update()
  {
    if (!pressed && !activated && !isOperating) {
      ready = true;
    } else {
      ready = false;
    }
    // Puzzle 1 Rules:
    if (puzzle1button1.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle1button2.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle1button2.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle1button4.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle1button3.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle1button1.GetComponent<PuzzleButtons>().activated = true;
      puzzle1button4.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle1button4.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle1button3.GetComponent<PuzzleButtons>().activated = true;
    }

    // Puzzle 2 Rules:
    if (puzzle2button1.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle2button2.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button3.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle2button2.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle2button5.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button8.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle2button3.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle2button5.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button7.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle2button4.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle2button5.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button6.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle2button5.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle2button2.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button4.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button6.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button8.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle2button6.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle2button4.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button5.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle2button7.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle2button3.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button5.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle2button8.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle2button2.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button5.GetComponent<PuzzleButtons>().activated = true;
    }
    if (puzzle2button9.GetComponent<PuzzleButtons>().pressed)
    {
      puzzle2button1.GetComponent<PuzzleButtons>().activated = true;
      puzzle2button5.GetComponent<PuzzleButtons>().activated = true;
    }

    if (!isOperating && (pressed || activated))
    {
      if (status == OnOff.on) {
        Debug.Log("Pressed and on");
        rend.sharedMaterial = material[1];
        isOperating = true;
        pressing = true;
        timer = timerLength;
      }
      else if (status == OnOff.off) {
        Debug.Log("Pressed and off");
        rend.sharedMaterial = material[0];
        isOperating = true;
        returning = true;
        timer = timerLength;
      }
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
      isOperating = false;
      status = OnOff.off;
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
      status = OnOff.on;
    }
    pressed = false;
    activated = false;
  }
}
