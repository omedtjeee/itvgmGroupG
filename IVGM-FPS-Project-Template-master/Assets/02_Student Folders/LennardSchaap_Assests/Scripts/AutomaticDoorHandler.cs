using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorHandler : MonoBehaviour
{
    float speed = 5f;
    bool isOpen = false;
    bool opening = false;
    bool closing = false;
    float timer;
    float timerLength = 1f;

    Vector3 door1DefaultPosition = new Vector3(0,0,0);
    Vector3 door2DefaultPosition = new Vector3(0,0,-3);

    public Transform door1;
    public Transform door2;
    Collider triggerZone;

    // Start is called before the first frame update
    void Start()
    {
      triggerZone = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
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
        closing = true;
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
    }

    void OnTriggerEnter (Collider other)
    {
      Damageable check = other.GetComponent<Damageable>();

      if (check == null) return;

      if (!isOpen)
      {
        isOpen = true;
        opening = true;
        timer = timerLength;
      }
    }
}
