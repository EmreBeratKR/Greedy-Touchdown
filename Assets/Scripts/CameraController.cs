﻿using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera
        playerNearFollow,
        playerFarFollow,
        playerLevelEndFollow;

    
    private CinemachineVirtualCamera[] virtualCameras;
    private CinemachineVirtualCamera[] VirtualCameras
    {
        get
        {
            if (virtualCameras == null)
            {
                virtualCameras = new[]
                {
                    playerNearFollow,
                    playerFarFollow,
                    playerLevelEndFollow
                };
            }

            return virtualCameras;
        }
    }


    public void OnPlayerNormalRun()
    {
        ChangeVirtualCamera(playerNearFollow);
    }

    public void OnPlayerFastRun()
    {
        ChangeVirtualCamera(playerFarFollow);
    }
    
    public void OnLevelEnd()
    {
        ChangeVirtualCamera(playerLevelEndFollow);
    }
    
    private void ChangeVirtualCamera(CinemachineVirtualCamera virtualCameraToActivate)
    {
        foreach (var virtualCamera in VirtualCameras)
        {
            virtualCamera.Priority = virtualCamera == virtualCameraToActivate ? 1 : 0;
        }
    }
}
