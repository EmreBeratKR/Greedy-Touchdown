using NaughtyAttributes;
using ScriptableEvents.Core.Channels;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private VoidEventChannel playerEnteredNextChunk;
        [SerializeField] private VoidEventChannel levelEnd;
        
        [Header("Tags")]
        [SerializeField, Tag] private string groundChunk;
        [SerializeField, Tag] private string endChunk;
        
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(groundChunk))
            {
                playerEnteredNextChunk.RaiseEvent();
            }
            
            if (other.CompareTag(endChunk))
            {
                levelEnd.RaiseEvent();
            }
        }
    }
}