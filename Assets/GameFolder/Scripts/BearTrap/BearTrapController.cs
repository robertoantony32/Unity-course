using GameFolder.Scripts.Player.Movement;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace GameFolder.Scripts.BearTrap
{
    public class BearTrapController : MonoBehaviour
    {

        public Transform player;
        public Transform skin;

        public Transform playerTrapped;

        public AudioSource audioSource;
        public AudioClip clip;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                audioSource.PlayOneShot(clip);
                skin.GetComponent<Animator>().Play("Stuck", -1);

                col.transform.position = playerTrapped.position;
                
                col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                
                col.GetComponent<PlayerController>()._animator.SetBool("PlayerRun", false);
                col.GetComponent<PlayerController>()._animator.Play("idle_animation", -1);

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                
                player = col.transform;
                
                col.GetComponent<PlayerController>().enabled = false;

                Invoke("ReleasePlayer", 2);
                Invoke("ResetTrap", 10);
            }
        }

        void ReleasePlayer()
        {
            player.GetComponent<PlayerController>().enabled = true;
        }


        void ResetTrap()
        {
            GetComponent<BoxCollider2D>().enabled = true;
            skin.GetComponent<Animator>().Play("UnStuck", -1);
        }
    }
}
