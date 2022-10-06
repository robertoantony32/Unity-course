using GameFolder.Scripts.Player.Movement;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace GameFolder.Scripts.BearTrap
{
    public class BearTrapController : MonoBehaviour
    {

        public Transform player;
        public Transform skin;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                skin.GetComponent<Animator>().Play("Stuck", -1);

                col.transform.position = transform.position;
                col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                
                col.GetComponent<PlayerController>()._animator.SetBool("PlayerRun", false);
                col.GetComponent<PlayerController>()._animator.Play("idle_animation", -1);

                GetComponent<BoxCollider2D>().enabled = false;
                
                player = col.transform;
                
                col.GetComponent<PlayerController>().enabled = false;
                
                Invoke("ReleasePlayer", 2);
            }
        }

        void ReleasePlayer()
        {
            player.GetComponent<PlayerController>().enabled = true;
        }
    }
}
