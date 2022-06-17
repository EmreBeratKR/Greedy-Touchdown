using UnityEngine;

namespace Particles
{
    public class CompositeParticle : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particleSystems;


        public void Play()
        {
            foreach (var particleSystem in particleSystems)
            {
                particleSystem.Play();
            }
        }
        
        public void Stop()
        {
            foreach (var particleSystem in particleSystems)
            {
                particleSystem.Stop();
            }
        }
    }
}
