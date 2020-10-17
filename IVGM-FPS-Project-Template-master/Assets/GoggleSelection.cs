using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoggleSelection : MonoBehaviour
{
    GameObject Green;
    GameObject Blue;
    GameObject Red;

    public Sprite ActiveSelect;
    public Sprite InactiveSelect;

    private void Start()
    {
        Green = gameObject.transform.GetChild(0).gameObject;
        Blue = gameObject.transform.GetChild(1).gameObject;
        Red = gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Green.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = ActiveSelect;
        }
    }
}
