using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovingTimer : MonoBehaviour
{
    public ControlPlayer controlPlayerScript;
    public float timer;
    public Animator animatorPlayer;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            controlPlayerScript.enabled = false;
            StartCoroutine(WaitSeconds());
            animatorPlayer.SetBool("MiscarePlayer", false);
            animatorPlayer.SetBool("isJumping", false);
            animatorPlayer.Play("AnimatiePlayerIdle");
        }
           
    }


    IEnumerator WaitSeconds() //asteapta
    {
        while (timer > 0f)
        {
            animatorPlayer.Play("AnimatiePlayerIdle");
            timer -= Time.deltaTime;
            yield return 0;
            if (timer <= 0f)
            {
                Destroy(this);
                controlPlayerScript.enabled = true;
            }
        }
    }
}


