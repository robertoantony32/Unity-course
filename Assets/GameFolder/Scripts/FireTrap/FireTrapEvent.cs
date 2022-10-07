using UnityEngine;

public class FireTrapEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;




    public void FireTrapSound()
    {
        audioSource.PlayOneShot(clip);
    }
}
