using UnityEngine;

namespace GameFolder.Scripts.FireTrap
{
    public class FireTrap : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            col.GetComponent<Charater>().PlayerDamage(1);
        }
        
    }
}
