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

        [Header("References")]
        [SerializeField] private CapsuleCollider mainCollider;
        
        [Header("Tags")]
        [SerializeField, Tag] private string groundChunk;
        [SerializeField, Tag] private string endChunk;
        [SerializeField, Tag] private string fellow;

        [Header("Values")]
        [SerializeField] private LayerMask dummies;
        [SerializeField] private float minDistanceWithFellow;



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
            }
            
            else if (other.CompareTag(endChunk))
            {
                levelEnd.RaiseEvent();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(mainCollider.transform.position + mainCollider.center, mainCollider.radius);
        }
    }
}