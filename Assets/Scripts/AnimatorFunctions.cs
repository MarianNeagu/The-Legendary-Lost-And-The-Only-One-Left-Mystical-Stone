using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] MainMenuController mainMenuController;
    public bool disableOnce;
    void PlaySound(AudioClip whichSound)
    {
        if (!disableOnce)
            mainMenuController.audioSource.PlayOneShot(whichSound);
        else
            disableOnce = false;
    }
}
