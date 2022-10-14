using System;
using System.Collections;
using System.Collections.Generic;
using GameFolder.Scripts.Bat;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{

    public Transform[] bat;
   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            foreach (Transform obj in bat)
            {
                obj.GetComponent<BatController>().enabled = true;
                obj.GetComponent<BatController>().player = col.transform;
            }
        }
    }
}
