using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public bool apasareE; // asta depinde de situatie. Se alege in functie de scena
    public TextMeshProUGUI pressToEnterText;
    private bool inTrigger;
    public string nextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && !apasareE)
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && apasareE)
            inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && inTrigger)
            inTrigger = false;
    }

    private void Start()
    {
        inTrigger = false;
        pressToEnterText.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Update()
    {
        if(inTrigger)
        {
            pressToEnterText.color = new Color(1f,1f,1f,1f);
        }
        else pressToEnterText.color = new Color(1f, 1f, 1f, 0f);
        if (Input.GetKey(KeyCode.E) && inTrigger)
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
            pressToEnterText.color = new Color(1f, 1f, 1f, 0f);
            inTrigger = false;
        }
            
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
