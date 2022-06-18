using Cinemachine;
using UnityEngine;

namespace CameraSystem
{
    public abstract class CameraController : MonoBehaviour
    {
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
                    virtualCameras = Cameras;
                }

                return virtualCameras;
            }
        }
        protected abstract CinemachineVirtualCamera[] Cameras { get; }

    
    
        protected void ChangeVirtualCamera(CinemachineVirtualCamera virtualCameraToActivate)
        {
            foreach (var virtualCamera in VirtualCameras)
            {
                virtualCamera.Priority = virtualCamera == virtualCameraToActivate ? 1 : 0;
            }
        }
    }
}
