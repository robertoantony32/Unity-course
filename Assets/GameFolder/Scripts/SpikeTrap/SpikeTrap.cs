using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
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
        if (!col.CompareTag("Player")) return;
        col.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        col.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 150));
        col.GetComponent<Charater>().PlayerDamage(1);
    }
}
