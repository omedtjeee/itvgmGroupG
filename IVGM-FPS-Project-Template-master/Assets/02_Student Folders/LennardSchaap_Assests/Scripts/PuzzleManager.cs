using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
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

  GameObject exit;
  GameObject elevatorbuttonspawn;

  public bool puzzle1completed = false;
  public bool puzzle2completed = false;

  // Start is called before the first frame update
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

    exit = GameObject.Find("EndManager");
    elevatorbuttonspawn = GameObject.Find("ElevatorButtonManager");

    exit.GetComponent<EndManager>().disabled = true;
    elevatorbuttonspawn.GetComponent<ElevatorButtonManager>().disabled = true;
  }

  // Update is called once per frame
  void Update()
  {
    if (puzzle1button1.GetComponent<PuzzleButtons>().ready &&
        puzzle1button2.GetComponent<PuzzleButtons>().ready &&
        puzzle1button3.GetComponent<PuzzleButtons>().ready &&
        puzzle1button4.GetComponent<PuzzleButtons>().ready &&
        puzzle2button1.GetComponent<PuzzleButtons>().ready &&
        puzzle2button2.GetComponent<PuzzleButtons>().ready &&
        puzzle2button3.GetComponent<PuzzleButtons>().ready &&
        puzzle2button4.GetComponent<PuzzleButtons>().ready &&
        puzzle2button5.GetComponent<PuzzleButtons>().ready &&
        puzzle2button6.GetComponent<PuzzleButtons>().ready &&
        puzzle2button7.GetComponent<PuzzleButtons>().ready &&
        puzzle2button8.GetComponent<PuzzleButtons>().ready &&
        puzzle2button9.GetComponent<PuzzleButtons>().ready)
      {
        // Puzzle 1 completed:
        if ((int)puzzle1button1.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle1button2.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle1button3.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle1button4.GetComponent<PuzzleButtons>().status == 1)
        {
          Debug.Log("puzzle 1 complete");
          puzzle1completed = true;

        }

        // Puzzle 2 completed:
        if ((int)puzzle2button1.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle2button2.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle2button3.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle2button4.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle2button5.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle2button6.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle2button7.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle2button8.GetComponent<PuzzleButtons>().status == 1 &&
            (int)puzzle2button9.GetComponent<PuzzleButtons>().status == 1)
        {
          Debug.Log("puzzle 2 complete");
          puzzle2completed = true;
        }

        if (puzzle1completed) {
          elevatorbuttonspawn.GetComponent<ElevatorButtonManager>().disabled = false;
          if (puzzle2completed) {
            exit.GetComponent<EndManager>().disabled = false;
          }
        }
      }
      else {
              Debug.Log("Ready");
      }
  }
}
