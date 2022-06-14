using NaughtyAttributes;
using ScriptableEvents.Core.Channels;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private const string DancePrefix = "dance";

        [Header("Event Channels")]
        [SerializeField] private VoidEventChannel playerThrowBall;

        [Header("References")] 
        [SerializeField] private LevelData levelData;
        [SerializeField] private Animator animator;

        [SerializeField, AnimatorParam(nameof(animator))]
        private int isRight, isLeft, speed;
        

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

        public void OnPlayerNormalRun()
        {
            animator.SetFloat(speed, 1f);
        }
        
        public void OnPlayerFastRun()
        {
            animator.SetFloat(speed, levelData.FastRunAnimatorMultiplier);
        }

        public void OnLevelEnd()
        {
            var danceType = Random.Range(1, 4);
            var danceTypeKey = DancePrefix + danceType;
            animator.SetTrigger(danceTypeKey);
        }

        public void RaisePlayerThrowBall()
        {
            playerThrowBall.RaiseEvent();
        }
    }
}
