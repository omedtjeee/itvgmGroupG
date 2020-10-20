using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour
{
  public float interactDistance;
  RaycastHit whatHit;
  GameObject player;
  GameObject manager;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.FindWithTag("Player");
    manager = GameObject.Find("PuzzleManager");
  }

  // Update is called once per frame
  void Update()
  {
    Debug.DrawRay(this.transform.position, this.transform.forward * interactDistance, Color.magenta);

    if (Physics.Raycast(this.transform.position, this.transform.forward, out whatHit, interactDistance))
    {
      if (Input.GetKeyDown (KeyCode.E))
      {
        if (whatHit.collider.tag == "Keycards")
        {
          if (whatHit.collider.gameObject.GetComponent<Keys>().whatKey == Keys.Keycards.redKeycard)
          {
            player.GetComponent<PlayerInventory>().hasRedKeycard = true;
            Destroy (whatHit.collider.gameObject);
          }
          else if (whatHit.collider.gameObject.GetComponent<Keys>().whatKey == Keys.Keycards.greenKeycard)
          {
            player.GetComponent<PlayerInventory>().hasGreenKeycard = true;
            Destroy (whatHit.collider.gameObject);
          }
          else if (whatHit.collider.gameObject.GetComponent<Keys>().whatKey == Keys.Keycards.blueKeycard)
          {
            player.GetComponent<PlayerInventory>().hasBlueKeycard = true;
            Destroy (whatHit.collider.gameObject);
          }
        }

        if (whatHit.collider.tag == "Buttons")
        {
          Debug.Log("Buttons");
          whatHit.collider.gameObject.GetComponentInParent<Buttons>().pressed = true;
        }
        else if (whatHit.collider.tag == "PuzzleButton")
        {
          Debug.Log("PuzzleButton");
          if (!manager.GetComponent<PuzzleManager>().puzzle1completed)
          {
            Debug.Log("puzzle1notcompleted");
              whatHit.collider.gameObject.GetComponentInParent<PuzzleButtons>().pressed = true;
          }
        }
        else if (whatHit.collider.tag == "Puzzle2Button")
        {
          Debug.Log("Puzzle2Button");
          if (!manager.GetComponent<PuzzleManager>().puzzle2completed)
          {
            Debug.Log("puzzle2notcompleted");
              whatHit.collider.gameObject.GetComponentInParent<PuzzleButtons>().pressed = true;
          }
        }
      }
    }
  }
}
