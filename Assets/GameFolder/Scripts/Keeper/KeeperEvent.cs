using UnityEngine;

public class KeeperEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackSound;
    
    
    public void KeeperAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }
}
