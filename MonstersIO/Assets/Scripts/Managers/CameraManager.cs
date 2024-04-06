using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public CinemachineVirtualCamera cinemachine;
    public CinemachineCameraOffset cameraOffset;
    private Transform player;

    private void Start()
    {
        instance = this;        
    }

    public void SetUpFollow()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player)
        {
            LimitingCameraPos();
        }
    }

    private void LimitingCameraPos()
    {
        float x = player.position.x;
        float y = player.position.y;

        if (Mathf.Abs(x) > 18 || Mathf.Abs(y) > 18)
        {
            cinemachine.Follow = null;
        }
        else
        {
            cinemachine.Follow = player;
        }

    }
}
