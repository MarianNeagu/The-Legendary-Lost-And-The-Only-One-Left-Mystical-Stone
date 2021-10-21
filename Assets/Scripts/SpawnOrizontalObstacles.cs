using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrizontalObstacles : MonoBehaviour
{
    public float delayBetweenObstacles;
    public Transform spawnLocation;
    public bool atFinish;
    public GameObject[] obstacles;
    public float time;
    public float force;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            StartCoroutine(Spawn());
    }

    private void Start()
    {
        time = delayBetweenObstacles;
    }
    IEnumerator Spawn()
    {
        while (time > 0f)
        {
            force = Random.Range(5f, 10f);
            time -= Time.deltaTime;
            yield return 0;
            if (time <= 0f)
            {
                if(!atFinish)
                {
                    Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnLocation.position, Quaternion.identity);
                    StartCoroutine(Spawn());
                    time = delayBetweenObstacles+Random.Range(0f,3f);
                }
                    
            }
                
        }
    }
}
