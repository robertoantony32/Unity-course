using UnityEngine;

namespace GameFolder.Scripts.Keeper
{
    public class KeeperController : MonoBehaviour
    {

        public Transform a;
        public Transform b;

        public bool goRight;

        public Transform keeperRender;
        public Transform keeperRange;


        void Update()
        {
            if (GetComponent<Charater>().life <= 0)
            {
                enabled = false;
                GetComponent<CapsuleCollider2D>().enabled = false;
                keeperRange.GetComponent<CircleCollider2D>().enabled = false;

            }
            
            if (keeperRender.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Keeper_Attack"))
            {
                return;
            }
        
            if (goRight)
            {
                keeperRender.localScale = new Vector3(0.35215f, 0.35215f, 0.35215f);
                if (Vector2.Distance(transform.position, b.position) < 0.1f)
                {
                    goRight = false;
                }
            
                transform.position = Vector3.MoveTowards(transform.position, b.position, 2.2f * Time.deltaTime);
            
            }
            else
            {
                keeperRender.localScale = new Vector3(-0.35215f, 0.35215f, 0.35215f);
                if (Vector2.Distance(transform.position, a.position) < 0.1f)
                {
                    goRight = true;
                
                }
                transform.position = Vector3.MoveTowards(transform.position, a.position, 2.2f * Time.deltaTime);
            
            }
        }
    }
}
