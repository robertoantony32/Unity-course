using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            transform.parent.GetComponent<Animator>().Play("Keeper_Attack", -1);
        }
    }
}
