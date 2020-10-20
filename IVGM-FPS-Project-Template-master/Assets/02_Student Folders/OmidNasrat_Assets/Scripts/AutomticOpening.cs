using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomticOpening : MonoBehaviour
{
  public float speed = 3f;
  bool isOpen = false;
  bool closing = false;
  bool opening = false;
  float timer;
  float timerLength = 1f;
  public bool key1 = false; //sleutel 1 al gepakt?
  public bool key2 = false; //idem maar dan sleutel 2

  public GameObject door1;
  public GameObject door2;
  public Collider triggerZone;

  Vector3 door1DefaultPosition = new Vector3(4.38f, 2.84f, -1.64f);
  Vector3 door2DefaultPosition = new Vector3(-3.41f,2.84f,1.49f);
    // Start is called before the first frame update
    void Start()
    {
      triggerZone = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
      if (opening && timer > 0f) {
        door2.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime * speed);
        door1.GetComponent<Transform>().Translate(-Vector3.right * Time.deltaTime * speed);
        timer -= Time.deltaTime;
      }
      else if(opening && timer <= 0f){
        opening = false;
        closing = true;
        timer = timerLength;
      }

      if(closing && timer > 0f){
        door2.GetComponent<Transform>().Translate(-Vector3.left * Time.deltaTime * speed);
        door1.GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime * speed);
        timer -= Time.deltaTime;
      }
      else if(closing && timer <=0f){
        closing = false;
        timer = timerLength;
        isOpen = false;
        door1.GetComponent<Transform>().localPosition = door1DefaultPosition;
        door2.GetComponent<Transform>().localPosition = door2DefaultPosition;
      }
    }

    void OnTriggerEnter (Collider other){
      Damageable player = other.GetComponent<Damageable>();
      if (player == null) {
        return;
      }
      if(!isOpen && key1 == true && key2 == true){
        isOpen = true;
        timer = timerLength;
        opening = true;
      }

    }
}
