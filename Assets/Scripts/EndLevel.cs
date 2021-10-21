using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public LevelChanger levelChanger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            levelChanger.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
