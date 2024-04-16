using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public CinemachineVirtualCamera cinemachine;
    private Transform player;

    private void Awake()
    {
        instance = this;        
    }

    public void Follow(PlayerController _player)
    {
        player = _player.transform;
        cinemachine.Follow = player.transform;
    }

    /*private void Update()
    {
        LimitingCameraPos();
    }

    public void LimitingCameraPos()
    {
        float x = player.position.x;
        float y = player.position.y;

        if (Mathf.Abs(x) > 20 || Mathf.Abs(y) > 16)
        {
            cinemachine.Follow = null;
        }
        else
        {
            cinemachine.Follow = player;
        }
    }*/
}
