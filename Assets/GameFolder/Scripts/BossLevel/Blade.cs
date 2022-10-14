using System;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;


    public Vector3 targetPosition;


    private void Start()
    {
        targetPosition = A.position;
    }

    private void Update()
    {
        if (transform.position == A.position)
        {
            targetPosition = B.position;
        }else if (transform.position == B.position)
        {
            targetPosition = C.position;
        }else if (transform.position == C.position)
        {
            targetPosition = D.position;
        }else if (transform.position == D.position)
        {
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);
        transform.Rotate(0, 0, -500 * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Charater>().PlayerDamage(1);
        }
    }
}
