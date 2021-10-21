using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolovaniScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

        }
    }

    void FixedUpdate()
    {
        rb.velocity = -Vector2.right * force;
    }
}
