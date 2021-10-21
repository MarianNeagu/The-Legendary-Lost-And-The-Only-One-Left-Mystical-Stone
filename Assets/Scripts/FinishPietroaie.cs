using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPietroaie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SfarsitPietre")
        {
            Destroy(gameObject);
            Debug.Log("distrus");
        }
            

    }
}
