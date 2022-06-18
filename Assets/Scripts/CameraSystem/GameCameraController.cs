using Cinemachine;
using UnityEngine;

namespace CameraSystem
{
    public class GameCameraController : CameraController
    {
        [SerializeField] private CinemachineVirtualCamera
            playerNearFollow,
            playerFarFollow,
            playerLevelEndFollow,
            gameOver;
    

        protected override CinemachineVirtualCamera[] Cameras
        {
            get
            {
                return new[]
                {
                    playerNearFollow,
                    playerFarFollow,
                    playerLevelEndFollow,
                    gameOver
                };
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
    }
}