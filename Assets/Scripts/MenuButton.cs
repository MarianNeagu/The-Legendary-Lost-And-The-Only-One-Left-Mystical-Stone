using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MainMenuController mainMenuController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainMenuController.index == thisIndex)
        {
    
            animator.SetBool("selected", true);
            if(Input.GetAxis("Submit") ==1)
            {
                animator.SetBool("pressed", true);
                if(thisIndex==0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    anim.SetTrigger("EndScene");

                }
                else
                    if(thisIndex==1)
                    {
                        mainMenu.SetActive(false);
                        optionsMenu.SetActive(true);
                        if(animator.GetBool("selected")==true)
                            animator.SetBool("selected", false);

                    }
                    else 
                        if(thisIndex==2)
                        {
                            Application.Quit();
                        }
                        
                        else
                            if(thisIndex==3)
                            {
                                mainMenu.SetActive(true);
                                optionsMenu.SetActive(false);
                                if (animator.GetBool("selected") == true)
                                    animator.SetBool("selected", false);
                            }

            }
            else if(animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }


    public void EndGame()
    {
        Application.Quit();
    }
}
