using GameFolder.Scripts.Player.Movement;
using UnityEngine;

namespace GameFolder.Scripts.Player
{
    public class AttackCollider : MonoBehaviour
    {
        public Transform player;

        private PlayerController _player;
        void Start()
        {
            _player = player.GetComponent<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Enemy")) return;
            if(_player.comboNum == 1){
                col.GetComponent<Charater>().life--;
            }else if (_player.comboNum > 1)
            {
                col.GetComponent<Charater>().PlayerDamage(2);
            }
        }
    }
}
