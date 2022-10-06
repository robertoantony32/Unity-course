using System;
using System.Collections;
using System.Collections.Generic;
using GameFolder.Scripts.Bat;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{

    public Transform[] bat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            foreach (Transform obj in bat)
            {
                obj.GetComponent<BatController>().enabled = true;
            }
        }
    }
}
