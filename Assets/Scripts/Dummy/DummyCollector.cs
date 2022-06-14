using NaughtyAttributes;
using ScriptableEvents.Core.Channels;
using UnityEngine;

namespace Dummy
{
    public class DummyCollector : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel fellowCollected;
        [SerializeField] private VoidEventChannel enemyCollected;
        
        [SerializeField, Tag] private string fellow, enemy;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(fellow))
            {
                fellowCollected.RaiseEvent();
            }
        
            else if (other.CompareTag(enemy))
            {
                enemyCollected.RaiseEvent();
            }
        }
    }
}
