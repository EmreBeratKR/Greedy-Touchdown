using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using ScriptableEvents.Core.Channels;
using UnityEngine;

namespace Player
{
    public class PlayerRagdoll : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private VoidEventChannel playerRagdollActivated;
        [SerializeField] private VoidEventChannel playerRagdollDeactivated;
        
        [Header("References")]
        [SerializeField] private Transform componentSearchRoot;
        [SerializeField] private Rigidbody mainBody;
        [SerializeField] private Collider mainCollider;
        [SerializeField] private Animator playerAnimator;
        
        [Header("Values")]
        [SerializeField, Tag] private string rugbyBall;
        [SerializeField] private Vector3 force;


        private List<Rigidbody> ragdollBodyParts;
        private List<Rigidbody> RagdollBodyParts
        {
            get
            {
                if (ragdollBodyParts == null)
                {
                    Rigidbody rugbyBallBody = null;
                    var bodies = componentSearchRoot.GetComponentsInChildren<Rigidbody>().ToList();
                    foreach (var body in bodies)
                    {
                        if (body.CompareTag(rugbyBall))
                        {
                            rugbyBallBody = body;
                        }
                    }

                    bodies.Remove(rugbyBallBody);
                    ragdollBodyParts = bodies;
                }

                return ragdollBodyParts;
            }
        }
        
        
        private List<Collider> ragdollColliders;
        private List<Collider> RagdollColliders
        {
            get
            {
                if (ragdollColliders == null)
                {
                    Collider rugbyBallCollider = null;
                    var colliders = componentSearchRoot.GetComponentsInChildren<Collider>().ToList();
                    foreach (var col in colliders)
                    {
                        if (col.CompareTag(rugbyBall))
                        {
                            rugbyBallCollider = col;
                        }
                    }
                    
                    colliders.Remove(rugbyBallCollider);
                    ragdollColliders = colliders;
                }

                return ragdollColliders;
            }
        }


        private void Start()
        {
            Deactivate();
        }

        public void OnGameOver()
        {
            Activate();
        }

        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void Activate()
        {
            ToggleRagdoll(true);
            playerRagdollActivated.RaiseEvent();
        }

        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void Deactivate()
        {
            ToggleRagdoll(false);
            playerRagdollDeactivated.RaiseEvent();
        }
        
        private void ToggleRagdoll(bool isActive)
        {
            mainBody.isKinematic = isActive;
            mainCollider.enabled = !isActive;
            playerAnimator.enabled = !isActive;
            
            foreach (var ragdollBodyPart in RagdollBodyParts)
            {
                ragdollBodyPart.isKinematic = !isActive;
            }

            foreach (var ragdollCollider in RagdollColliders)
            {
                ragdollCollider.enabled = isActive;
            }
            
            ragdollBodyParts[0].AddForce(force, ForceMode.VelocityChange);
        }
    }
}
