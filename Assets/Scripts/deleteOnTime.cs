using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteOnTime : MonoBehaviour
{
    public float timpAutodistrugere;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            StartCoroutine(WaitSeconds());
        }
    }
    IEnumerator WaitSeconds() //asteapta
    {
        while (timpAutodistrugere > 0f)
        {
            timpAutodistrugere -= Time.deltaTime;
            yield return 0;
            if (timpAutodistrugere <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
