using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReplayMenuScript : MonoBehaviour
{
    public GameObject restartMenu;
    public PauseMenu pauseMenuScript;
    public ControlPlayer controlScript;
    private void Start()
    {
        Time.timeScale = 1f;
        restartMenu.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacol")
        {
            Debug.Log("dead");
            restartMenu.SetActive(true);
            pauseMenuScript.isDead = true;
            controlScript.enabled = false;
            Time.timeScale = 0f;
        } 
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Scena4");
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

}
