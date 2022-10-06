using UnityEngine;

public class AddHeart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Charater>().life++;
            Destroy(transform.gameObject);
        }
    }
}
