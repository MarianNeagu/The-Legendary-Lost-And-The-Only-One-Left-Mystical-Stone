using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    public Collider2D collider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            collider.isTrigger = false;
    }

}
