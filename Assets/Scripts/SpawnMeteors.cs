using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour
{
    public Transform[] spawnLocations;
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject[] meteor;
    public float timpSpawn;
    private bool inTrigger=false;
    // Start is called before the first frame update
    void Start()
    {
        timpSpawn = 0f;
        timeBtwSpawns = startTimeBtwSpawns;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!inTrigger)
            {
                timpSpawn = 300f;
                inTrigger = true;
            }
            
        }
    }
    void Update()
    {
        if(timpSpawn>=0f)
        {
            if (timeBtwSpawns >= 0)
            {
                timeBtwSpawns -= Time.deltaTime;
                if (timeBtwSpawns <= 0)
                {
                    int randomNumber = Random.Range(0, spawnLocations.Length);
                    Debug.Log(randomNumber);

                    switch (randomNumber)
                    {
                        case 0:
                            Instantiate(meteor[Random.Range(0, meteor.Length)], spawnLocations[0].position, Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(meteor[Random.Range(0, meteor.Length)], spawnLocations[1].position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(meteor[Random.Range(0, meteor.Length)], spawnLocations[2].position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(meteor[Random.Range(0, meteor.Length)], spawnLocations[3].position, Quaternion.identity);
                            break;
                    }
                    timeBtwSpawns = startTimeBtwSpawns;
                }
            }
            timpSpawn -= Time.deltaTime;
        }
        

    }
}
