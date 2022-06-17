using UnityEngine;

namespace Particles
{
    public class ParticleContainer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particleSystems;


        public void PlayRandom()
        {
            var randomParticle = particleSystems[Random.Range(0, particleSystems.Length)];
            randomParticle.Play();
        }
    }
}
