using Cinemachine;
using UnityEngine;

namespace CameraSystem
{
    public class FittingRoomCameraController : CameraController
    {
        [SerializeField] private CinemachineVirtualCamera
            baseCamera,
            uniformFocusCamera,
            playerFocusCamera;
    

        protected override CinemachineVirtualCamera[] Cameras
        {
            get
            {
                return new[]
                {
                    baseCamera,
                    uniformFocusCamera,
                    playerFocusCamera
                };
            }
        }


        public void OnCancelSelection()
        {
            ChangeVirtualCamera(baseCamera);
        }
    
        public void OnUniformNumberSelection()
        {
            ChangeVirtualCamera(uniformFocusCamera);
        }

        public void OnPlayerTypeSelection()
        {
            ChangeVirtualCamera(playerFocusCamera);
        }
    }
}