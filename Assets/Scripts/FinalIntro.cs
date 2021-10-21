using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalIntro : MonoBehaviour
{
    public SpriteRenderer[] luminiReflectoare;

    public float vitezaAnimatie;
    public float delayAnimatie;
    public float delayInceput;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            StartCoroutine(DelayInceput());
    }

    IEnumerator DelayInceput()
    {
        while (delayInceput > 0f)
        {
            delayInceput -= Time.deltaTime;
            yield return 0;
            if (delayInceput <= 0f)
                StartCoroutine(Animatie());
        }
    }

    IEnumerator Animatie()
    {
        for (int i = 0; i < luminiReflectoare.Length; i++)
        {
            Debug.Log(i);
            Debug.Log("La inceput: " + luminiReflectoare[i].color.a);
            float time = 89/255f;
            while (time >= 0f) // Apare replica
            {

                time -= Time.deltaTime * vitezaAnimatie;
                luminiReflectoare[i].color = new Color(luminiReflectoare[i].color.r,
                                                   luminiReflectoare[i].color.g,
                                                   luminiReflectoare[i].color.b,
                                                   time);
                Debug.Log(luminiReflectoare[i].color.a);
                yield return 0;
                if (time <= 0f)
                {
                    while (delayAnimatie > 0f)
                    {
                        delayAnimatie -= Time.deltaTime;
                        yield return 0;
                    }
                }
            }
        }
    }

}
