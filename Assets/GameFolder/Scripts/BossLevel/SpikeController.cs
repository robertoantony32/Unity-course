using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] Transform boss;

    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            boss = col.transform;
            col.GetComponent<BossController>().enabled = false;
            col.transform.parent = transform;
            col.transform.localPosition = Vector3.zero;
        }
    }


    public void CollisionSound()
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
    
    public void ReleaseBoss()
    {
        if (boss != null)
        {
            boss.GetComponent<BossController>().enabled = true;
            boss.parent = null;
        }
    }
}
