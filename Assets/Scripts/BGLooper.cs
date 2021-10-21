using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    public float nrSprites;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D colliider)
    {
        Debug.Log(colliider.name);
        float width = colliider.GetComponent<Collider2D>().bounds.size.x;
        Vector3 pos = colliider.transform.position;
        pos.x += width * nrSprites;
        colliider.transform.position = pos;

    }
}