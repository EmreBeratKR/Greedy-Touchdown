using ScriptableEvents.Core.Channels;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private VoidEventChannel playerTurnRight;
        [SerializeField] private VoidEventChannel playerTurnLeft;
        [SerializeField] private VoidEventChannel playerTurnStraight;

        [Header("Values")]
        [SerializeField, Min(0f)] private float verticalSpeed;
        [SerializeField, Min(0f)] private float runSpeed;
        [SerializeField, Min(0f)] private float borderX;

        private Rigidbody body;
        private MotionMode motionMode;
        private State state;


        private void Start()
        {
            body = GetComponent<Rigidbody>();
            
            StartRunning();
        }

        private void Update()
        {
            SetForwardSpeed();
            CheckBorder();
            MoveVertical();
        }

        public void OnPointerDown()
        {
            if (motionMode == MotionMode.Left) return;
            
            motionMode = MotionMode.Left;
            playerTurnLeft.RaiseEvent();
        }

        public void OnPointerUp()
        {
            if (motionMode == MotionMode.Right) return;
            
            motionMode = MotionMode.Right;
            playerTurnRight.RaiseEvent();
        }

        private void CheckBorder()
        {
            if (motionMode == MotionMode.Straight) return;
            
            var positionX = body.position.x;
            
            if (motionMode == MotionMode.Right)
            {
                if (positionX < borderX) return;

                motionMode = MotionMode.Straight;
                playerTurnStraight.RaiseEvent();
            }
            
            else if (motionMode == MotionMode.Left)
            {
                if (positionX > -borderX) return;

                motionMode = MotionMode.Straight;
                playerTurnStraight.RaiseEvent();
            }
        }

        private void MoveVertical()
        {
            var speedX = verticalSpeed * (float) motionMode;

            var oldVelocity = body.velocity;
            oldVelocity.x = speedX;
            body.velocity = oldVelocity;
        }

        private void StartRunning()
        {
            state = State.Run;
        }
        
        private void StopRunning()
        {
            state = State.Idle;
        }

        private void SetForwardSpeed()
        {
            var speed = state == State.Run ? runSpeed : 0f;
            var oldVelocity = body.velocity;
            oldVelocity.z = speed;
            body.velocity = oldVelocity;
        }
        
        
        private enum MotionMode
        {
            Right = 1,
            Left = -1,
            Straight = 0
        }
        
        private enum State
        {
            Idle,
            Run,
            Dance
        }
    }
}
