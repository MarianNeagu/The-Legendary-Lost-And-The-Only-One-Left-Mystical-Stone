using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DepartareCamera : MonoBehaviour
{

    public CinemachineVirtualCamera virtualCamera;
    public float cameraSpeed;
    public float ortographicSizeInitiala;
    public float ortographicSizeExtinsa;
    public float delayInceput;
    public float timerCameraExtinsa;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            StartCoroutine(WaitSeconds1());
    }

    IEnumerator WaitSeconds1() //asteapta
    {
        while (delayInceput > 0f)
        {
            delayInceput -= Time.deltaTime;
            yield return 0;
            if (delayInceput <= 0f)
                StartCoroutine(DepartareCam());

        }
    }

    IEnumerator DepartareCam()
    {
        while(virtualCamera.m_Lens.OrthographicSize < ortographicSizeExtinsa)
        {
            virtualCamera.m_Lens.OrthographicSize += Time.deltaTime * cameraSpeed;
            if(virtualCamera.m_Lens.OrthographicSize >= ortographicSizeExtinsa)
            {
                virtualCamera.m_Lens.OrthographicSize = ortographicSizeExtinsa;
                StartCoroutine(WaitSeconds2());
            }
            yield return 0;
        }
    }


    IEnumerator WaitSeconds2() //asteapta
    {
        while (timerCameraExtinsa > 0f)
        {
            timerCameraExtinsa -= Time.deltaTime;
            yield return 0;
            if (timerCameraExtinsa <= 0f)
                StartCoroutine(ApropiereCamera());

        }
    }


    IEnumerator ApropiereCamera()
    {
        while (virtualCamera.m_Lens.OrthographicSize > ortographicSizeInitiala)
        {
            virtualCamera.m_Lens.OrthographicSize -= Time.deltaTime * cameraSpeed;
            if (virtualCamera.m_Lens.OrthographicSize <= ortographicSizeInitiala)
            {
                virtualCamera.m_Lens.OrthographicSize = ortographicSizeInitiala;
                break;
            }
            yield return 0;
        }
    }

}
