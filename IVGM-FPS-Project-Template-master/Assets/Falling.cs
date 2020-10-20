﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public Transform thePlataform;
    private bool Moving = false;
    private bool PlataformGrounded = true;


    void Update()
    {
        if (Moving == true)
        {
            StartCoroutine("ChangeState");
        }
    }
    void OnTriggerEnter(Collider theCollider)
    {
        if (theCollider.CompareTag("Player"))
        {
            Moving = true;
        }
    }
    void OnTriggerExit(Collider theCollider)
    {
        if (theCollider.CompareTag("Player"))
        {
            Moving = false;

        }
    }
    IEnumerator ChangeState()
    {
        if (PlataformGrounded == true)
        {
            thePlataform.GetComponent<Animation>().CrossFade("Down");
            PlataformGrounded = false;
            yield return new WaitForSeconds(3.0f);
        }
    }
}