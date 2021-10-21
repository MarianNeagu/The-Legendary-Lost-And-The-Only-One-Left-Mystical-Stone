using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrediteIntro : MonoBehaviour
{
    public Animator crediteAnimator;
    public float delayInceput;
    public AudioSource muzicaFundal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            StartCoroutine(Delay());  
    }

    private void Start()
    {
        crediteAnimator.SetBool("boolCredite", false);
    }

    IEnumerator Delay()
    {
        while (delayInceput > 0f)
        {
            delayInceput -= Time.deltaTime;
            yield return 0;
            if (delayInceput <= 0f)
            {
                crediteAnimator.SetBool("boolCredite", true);
                delayInceput = 12f;
                while(delayInceput > 0f)
                {
                    delayInceput -= Time.deltaTime;
                    yield return 0;
                    if (delayInceput <= 0f)
                        muzicaFundal.volume = 0f;
                }
                
            }
                
        }
    }
}
