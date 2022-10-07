using UnityEngine;

namespace GameFolder.Scripts.SpikeTrap
{
    public class SpikeTrap2Sound : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip clip;

        public void PlaySound()
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
