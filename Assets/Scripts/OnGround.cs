using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
   public  ControlPlayer player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground(canJump)")
            player.onGround = true;
    }

}
