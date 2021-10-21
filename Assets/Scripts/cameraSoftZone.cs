using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cameraSoftZone : MonoBehaviour
{
    public float deadZone;
    public CinemachineVirtualCamera vcam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var composer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
            composer.m_DeadZoneWidth = deadZone;
        }
    }
}
