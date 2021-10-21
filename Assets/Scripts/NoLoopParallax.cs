using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLoopParallax : MonoBehaviour
{
    public GameObject cam;
    private float length, startpos;
    public float parallaxEffect;

    private void Start()
    {
        startpos = transform.position.x;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);



    }
}
