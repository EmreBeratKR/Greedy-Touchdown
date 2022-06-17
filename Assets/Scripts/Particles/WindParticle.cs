using UnityEngine;

namespace Particles
{
    [RequireComponent(typeof(ParticleSystem))]
    public class WindParticle : MonoBehaviour
    {
        private new ParticleSystem particleSystem;


        private void Start()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            transform.LookAt(CameraController.MainCamera.transform.position);
        }

        public void Enable()
        {
            if (particleSystem.isEmitting) return;
            
            particleSystem.Play();
        }

        public void Disable()
        {
            if (particleSystem.isStopped) return;
            
            particleSystem.Stop();
        }
    }
}
