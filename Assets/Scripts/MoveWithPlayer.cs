using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public float dist;
    public GameObject player;
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + dist, transform.position.y, transform.position.z);
    }
}
