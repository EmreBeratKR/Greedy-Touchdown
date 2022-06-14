using NaughtyAttributes;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private const string DancePrefix = "dance";
        
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
            animator.SetBool(isLeft, true);
        }
        
        public void OnPlayerTurnedStraight()
        {
            animator.SetBool(isRight, false);
            animator.SetBool(isLeft, false);
        }

        public void OnLevelEnd()
        {
            var danceType = Random.Range(1, 4);
            var danceTypeKey = DancePrefix + danceType;
            animator.SetTrigger(danceTypeKey);
        }
    }
}
