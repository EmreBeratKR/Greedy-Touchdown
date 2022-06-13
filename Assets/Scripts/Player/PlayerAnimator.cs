using NaughtyAttributes;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        [SerializeField, AnimatorParam(nameof(animator))]
        private int isRight, isLeft;
        
        

        public void OnPlayerTurnedRight()
        {
            animator.SetBool(isRight, true);
            animator.SetBool(isLeft, false);
        }
        
        public void OnPlayerTurnedLeft()
        {
            animator.SetBool(isRight, false);
            animator.SetBool(isLeft, transform);
        }
        
        public void OnPlayerTurnedStraight()
        {
            animator.SetBool(isRight, false);
            animator.SetBool(isLeft, false);
        }
    }
}
