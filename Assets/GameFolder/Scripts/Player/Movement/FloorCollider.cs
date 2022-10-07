
using System;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    public bool canJump;

    public AudioSource audioSource;
    public AudioClip groundedSound;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Floor"))
        {
            canJump = true;
            audioSource.PlayOneShot(groundedSound, 0.5f);
        }
    }
}
