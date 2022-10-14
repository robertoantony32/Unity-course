using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform player;
    private void OnEnable()
    {
        player = GameObject.Find("PlayerPivot").transform;
        transform.right = transform.position - player.position;
    }
    void Update()
    {
        transform.position += transform.right * -5 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Charater>().PlayerDamage(1);
        }
    }
}
