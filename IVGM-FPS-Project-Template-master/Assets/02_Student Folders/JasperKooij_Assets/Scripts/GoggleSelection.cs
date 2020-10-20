using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoggleSelection : MonoBehaviour
{
    public GameObject Blue;
    public GameObject Red;
    public GameObject Green;

    public Sprite ActiveSelect;
    public Sprite InactiveSelect;

    public Sprite ActiveBlue, ActiveRed, ActiveGreen;

    public Sprite DeselectBlue, DeselectRed, DeselectGreen, DeselectGoggle;

    private int index = -1;
    private int collected = 0;

    private void Start()
    {
        Blue = gameObject.transform.GetChild(0).gameObject;
        Red = gameObject.transform.GetChild(1).gameObject;
        Green = gameObject.transform.GetChild(2).gameObject;

    }

    public int getCollected()
    {
        return collected;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && collected > 0)
        {
            NextGoggle(ref index, collected);
        }
        if(Input.GetMouseButtonDown(1))
        {
            NoGoggle(ref index);
        }
    }

    private void SelectGoggle(int index)
    {
        HideArrows();
        ShowArrow(index);
        ShowDeselectGoggle(index);
        PlatformManager.Instance.ShowPlatforms(index);
    }

    private void ShowDeselectGoggle(int index)
    {
        Sprite s = DeselectGoggle;
        switch (index)
        {
            case -1:
                break;
            case 0:
                s = DeselectBlue;
                break;
            case 1:
                s = DeselectRed;
                break;
            case 2:
                s = DeselectGreen;
                break;
        }
        GameObject.FindGameObjectWithTag("DeselectGoggle").gameObject.GetComponent<Image>().sprite = s;
    }

    private void DeselectGoggles()
    {
        HideArrows();
        ShowDeselectGoggle(-1);
        PlatformManager.Instance.HidePlatforms();
    }

    private void ShowArrow(int index)
    {
        gameObject.transform.GetChild(index).gameObject.transform.GetChild(1).GetComponent<Image>().sprite = ActiveSelect;
    }

    private void HideArrows()
    {
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Image>().sprite = InactiveSelect;
        gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<Image>().sprite = InactiveSelect;
        gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).GetComponent<Image>().sprite = InactiveSelect;
    }

    private void NextGoggle(ref int index, int collected)
    {
        index = (index + 1) % collected;
        SelectGoggle(index);
    }

    private void NoGoggle(ref int index)
    {
        DeselectGoggles();
        index = -1;
    }

    public void Collected()
    {
        collected++;
        switch(collected)
        {
            case 1:
                gameObject.transform.GetChild(collected-1).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ActiveBlue;
                DoorHandler.Instance.BlueCollected();
                break;
            case 2:
                gameObject.transform.GetChild(collected-1).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ActiveRed;
                DoorHandler.Instance.RedCollected();
                break;
            case 3:
                gameObject.transform.GetChild(collected-1).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ActiveGreen;
                DoorHandler.Instance.GreenCollected();
                break;
        }
    }
}
