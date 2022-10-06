using System;
using UnityEngine;

namespace GameFolder.Scripts.Ghost
{
    public class GhostController : MonoBehaviour
    {
        public Transform a;
        public Transform b;

        public bool goRight;

        public Transform ghostRender;
        
        void Update()
        {
            if (goRight)
            {
                ghostRender.localScale = new Vector3(-1f, 1, 1);
                if (Vector2.Distance(transform.position, b.position) < 0.1f)
                {
                    transform.position = a.position;
                }
            
                transform.position = Vector3.MoveTowards(transform.position, b.position, 15f * Time.deltaTime);
            
            }
            else
            {
                ghostRender.localScale = new Vector3(1, 1, 1);
                if (Vector2.Distance(transform.position, a.position) < 0.1f)
                {
                    transform.position = b.position;

                }
                transform.position = Vector3.MoveTowards(transform.position, a.position, 15f * Time.deltaTime);
            
            }
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<Charater>().PlayerDamage(1);
            }
        }
    }
}
