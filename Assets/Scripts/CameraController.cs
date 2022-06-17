using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera
        playerNearFollow,
        playerFarFollow,
        playerLevelEndFollow,
        gameOver;


    private static Camera mainCamera;
    public static Camera MainCamera
    {
        get
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            return mainCamera;
        }
    }
    
    
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
                    playerLevelEndFollow,
                    gameOver
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

    public void OnGameOver()
    {
        ChangeVirtualCamera(gameOver);
    }
    
    private void ChangeVirtualCamera(CinemachineVirtualCamera virtualCameraToActivate)
    {
        foreach (var virtualCamera in VirtualCameras)
        {
            virtualCamera.Priority = virtualCamera == virtualCameraToActivate ? 1 : 0;
        }
    }
}
