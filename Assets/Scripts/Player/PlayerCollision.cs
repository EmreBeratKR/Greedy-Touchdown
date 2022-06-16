using ChunkSystem;
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
        [SerializeField] private VoidEventChannel gameOver;

        [Header("References")]
        [SerializeField] private CapsuleCollider mainCollider;
        
        [Header("Tags")]
        [SerializeField, Tag] private string groundChunk;
        [SerializeField, Tag] private string endChunk;
        [SerializeField, Tag] private string fellow;
        [SerializeField, Tag] private string enemy;

        [Header("Values")]
        [SerializeField] private LayerMask dummies;
        [SerializeField] private float minDistanceWithFellow;


        public Chunk CurrentChunk { get; private set; }
        

        public bool IsBlockedByFellow
        {
            get
            {
                var isHit = Physics.SphereCast(
                    mainCollider.transform.position + mainCollider.center,
                    mainCollider.radius,
                    transform.forward,
                    out var hitInfo,
                    minDistanceWithFellow,
                    dummies
                );

                return isHit && hitInfo.collider.CompareTag(fellow);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(groundChunk))
            {
                playerEnteredNextChunk.RaiseEvent();
                CurrentChunk = other.GetComponentInParent<Chunk>();
            }
            
            else if (other.CompareTag(endChunk))
            {
                levelEnd.RaiseEvent();
                CurrentChunk = other.GetComponentInParent<Chunk>();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(enemy))
            {
                gameOver.RaiseEvent();
            }
        }
    }
}