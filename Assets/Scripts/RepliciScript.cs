using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RepliciScript : MonoBehaviour
{
    public TextMeshProUGUI[] replica;
    public bool replicaFinalizata;
    public float alphaSpeed;
    private float timer; // timer replica
    public float vitezaReplici;
    bool inTrigger;
    public float vitezaIntreReplici;
    public float delayInceput;

    private void Start()
    {
        for(int i=0;i<replica.Length;i++)
            replica[i].color = new Color(replica[i].color.r, replica[i].color.g, replica[i].color.b, 0);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !inTrigger)
        {
            if(delayInceput!=0f)
                StartCoroutine(DelayInceput());// se da fadeIn replica dupa replica
            else StartCoroutine(FadeInReplici());
            inTrigger = true;
        }
             
    }

    IEnumerator DelayInceput()
    {
        while (delayInceput > 0f)
        {
            delayInceput -= Time.deltaTime;
            yield return 0;
            if (delayInceput <= 0f)
                StartCoroutine(FadeInReplici());

        }
    }

    IEnumerator FadeInReplici()
    {
        for (int i = 0; i < replica.Length; i++)
        {
            float time = 0f;
            while (time <= 2f) // Apare replica
            {

                time += Time.deltaTime * alphaSpeed;
                replica[i].color = new Color(replica[i].color.r,
                                                   replica[i].color.g,
                                                   replica[i].color.b,
                                                   time);
                yield return 0;
                if (time >= 2f)
                {
                    timer = 0f;  
                        while (timer <= 10f)// Astepti sa citesti replica
                    {
                            timer += Time.deltaTime * vitezaReplici;
                            yield return 0;
                            if (timer >= 10f)
                            {
                                float time1 = 2f;
                                while (time1 >= 0f) // Dispare replica
                                {
                                    time1 -= Time.deltaTime * alphaSpeed;
                                    replica[i].color = new Color(replica[i].color.r,
                                                                       replica[i].color.g,
                                                                       replica[i].color.b,
                                                                       time1);
                                    yield return 0;
                                    if(time1<=0f)
                                    {
                                        timer = 0f;
                                        while (timer <= 10f)
                                        {
                                            timer += Time.deltaTime * vitezaIntreReplici;
                                            yield return 0;

                                        }

                                    }
                                }

                            }   
                        }
                }
            }
        } 
    }





}
