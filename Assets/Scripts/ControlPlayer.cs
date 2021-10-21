using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{

    public Animator animatorPlayer;
    public Transform playerTransform;
    public Rigidbody2D rb;
    public bool mersDreapta;
    public bool mersStanga;
    public float jumpForce = 1f;
    public bool onGround;
    private bool isJumping;
    public float moveSpeed;
    public LayerMask layerMask;
    public AudioSource[] sunetePasi;
    public AudioSource sunetJump;
    public ParticleSystem particleSystem;



    private void FixedUpdate()
    {

        onGround = Physics2D.OverlapArea(new Vector2(transform.position.x, transform.position.y - 16.12f), new Vector2(transform.position.x + 6.74f, transform.position.y + 1.15f), layerMask);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MersDreapta();
            //rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime);
            transform.Translate(moveSpeed, 0f, 0f);
            if(onGround==true)
            particleSystem.Emit(10);        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.MovePosition(rb.position - moveSpeed * Time.fixedDeltaTime);
            MersStanga();
            transform.Translate(moveSpeed, 0f, 0f);
            if(onGround==true)
            particleSystem.Emit(10);
        }
        else
            Idle();

        if (Input.GetKeyDown(KeyCode.Space) && onGround==true)
        {
            //StartCoroutine(DelayPrepare());
            rb.velocity = Vector2.up * jumpForce;
            particleSystem.Emit(80);
            animatorPlayer.SetTrigger("Prepare");
        }

        if (!onGround)
        {
            animatorPlayer.SetBool("isJumping", true);
        }
        else
        {
            animatorPlayer.SetBool("isJumping", false);
        }



    }

    IEnumerator DelayPrepare()
    {
        float timer=0.25f;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return 0;
            if (timer <= 0f)
                rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);

        }
    }

    public void Idle()
    {
        animatorPlayer.SetBool("MiscarePlayer", false);

    }

    public void MersDreapta()
    {
        animatorPlayer.SetBool("MiscarePlayer", true);

        playerTransform.rotation = Quaternion.Euler(playerTransform.rotation.x, 0, playerTransform.rotation.z);

    }

    public void MersStanga()
    {
        animatorPlayer.SetBool("MiscarePlayer", true);

        playerTransform.rotation = Quaternion.Euler(playerTransform.rotation.x, -180, playerTransform.rotation.z);

    }
   
    public void SunetJump()
    {
        sunetJump.Play();
    }
    public void SunetPasi()
    {
        sunetePasi[Random.Range(0,sunetePasi.Length-1)].Play();
    }

}
