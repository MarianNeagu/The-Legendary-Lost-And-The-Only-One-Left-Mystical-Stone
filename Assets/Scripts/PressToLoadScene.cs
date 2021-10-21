using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PressToLoadScene : MonoBehaviour
{
    public string sceneToLoad;
    private bool inTrigger = false;
    public TextMeshProUGUI textE;
    public bool pressed= false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            inTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            inTrigger = false;
    }

    private void Update()
    {
        if(inTrigger && !pressed)
        {
            textE.color = new Color(1f, 1f, 1f, 1f);
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
                pressed = true;
            }
                
            
        }
        else
        {
            textE.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
