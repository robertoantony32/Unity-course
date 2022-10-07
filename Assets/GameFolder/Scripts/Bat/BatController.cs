using UnityEngine;

namespace GameFolder.Scripts.Bat
{
    public class BatController : MonoBehaviour
    {

        public Transform player;

        public float attackTime;
    
        // Start is called before the first frame update
        void Start()
        {
            attackTime = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (GetComponent<Charater>().life <= 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().gravityScale = 1;
                enabled = false;
            } 
            if (Vector2.Distance(transform.position, player.GetComponent<CapsuleCollider2D>().bounds.center) > 1f)
            {
                attackTime = 0;
                transform.position = Vector2.MoveTowards(transform.position, player.position, 2.7f * Time.deltaTime);
            }
            else
            {
                attackTime += Time.deltaTime;
                if (attackTime >= 0.6f)
                {
                    attackTime = 0;
                    player.GetComponent<Charater>().PlayerDamage(1);
                }
            }
        }
    }
}
