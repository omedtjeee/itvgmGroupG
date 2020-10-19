using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoggleSelection : MonoBehaviour
{
    GameObject Blue;
    GameObject Red;
    GameObject Green;

    public Sprite ActiveSelect;
    public Sprite InactiveSelect;

    public Sprite ActiveBlue, ActiveRed, ActiveGreen;

    private int index = 0;
    private int collected = 0;

    private void Start()
    {
        Blue = gameObject.transform.GetChild(0).gameObject;
        Red = gameObject.transform.GetChild(1).gameObject;
        Green = gameObject.transform.GetChild(2).gameObject;

    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && collected > 0)
        {
            NextGoggle(ref index, collected);
            // Green.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = ActiveSelect;
        }
        if(Input.GetMouseButtonDown(1))
        {
            NoGoggle(ref index);
        }
    }

    private void NextGoggle(ref int index, int collected)
    {
        if (index >= 0)
            gameObject.transform.GetChild(index).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = InactiveSelect;

        //pc.ShowPlatform(index+1%3);
        PlatformController.Instance.ShowPlatform(index);
        if (index < collected - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
        gameObject.transform.GetChild(index).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = ActiveSelect;
    }

    private void NoGoggle(ref int index)
    {
        gameObject.transform.GetChild(index).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = InactiveSelect;
        index = -1;
        PlatformController.Instance.ShowPlatform(0);
    }

    public void Collected()
    {
        collected++;
        switch(collected)
        {
            case 1:
                gameObject.transform.GetChild(collected-1).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ActiveBlue;
                break;
            case 2:
                gameObject.transform.GetChild(collected-1).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ActiveRed;
                break;
            case 3:
                gameObject.transform.GetChild(collected-1).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ActiveGreen;
                break;
        }
    }
}
