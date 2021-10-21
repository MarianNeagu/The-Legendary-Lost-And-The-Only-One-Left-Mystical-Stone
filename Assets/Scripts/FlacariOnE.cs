using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FlacariOnE : MonoBehaviour
{
    public SpriteRenderer buton;
    public TextMeshProUGUI pressEText;
    private bool inTrigger=false;
    public ParticleSystem[] particleSystem;
    private bool pressed = false;

    private void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            inTrigger = true;
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            inTrigger = false;

            
    }
    private void Update()
    {
        if(inTrigger && !pressed)
        {
            pressEText.color = new Color(1f, 1f, 1f, 1f);
            //flacari
            if (Input.GetKeyDown(KeyCode.E) && !pressed)
            {
                pressed = true;
                buton.color = new Color(buton.color.r - 0.5f, buton.color.g - 0.5f, buton.color.b - 0.5f, buton.color.a);
                pressEText.color = new Color(1f, 1f, 1f, 0f);
                for (int i = 0; i < particleSystem.Length; i++)
                    particleSystem[i].Play();
            }
                
        }
        else pressEText.color = new Color(1f, 1f, 1f, 0f);
    }
}
