using System;
using UnityEngine;

public class PoleController : MonoBehaviour
{
    public Transform spike;
    public AudioClip sound;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Equals("AttackCollider"))
        {
            spike.GetComponent<Animator>().Play("Spike", -1);
            GetComponent<Animator>().Play("Pole", -1);
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}
