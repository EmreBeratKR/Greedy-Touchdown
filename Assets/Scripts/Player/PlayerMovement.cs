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
        [SerializeField] private VoidEventChannel playerNormalRun;
        [SerializeField] private VoidEventChannel playerFastRun;

        [Header("References")]
        [SerializeField] private PlayerCollision playerCollision;
        [SerializeField] private LevelData levelData;
        
        [Header("Values")]
        [SerializeField, Min(0f)] private float verticalSpeed;
        [SerializeField, Min(0f)] private float runSpeed;

        private Rigidbody body;
        private RunSpeedMode runSpeedMode;
        private RunMode runMode;
        private State state;
        


        private void Start()
        {
            body = GetComponent<Rigidbody>();
            body.position = Vector3.right * levelData.BorderX;
            
            StartRunning();
        }

        private void Update()
        {
            UpdateRunSpeedMode();
            SetForwardSpeed();
            CheckBorder();
            MoveVertical();
        }

        public void OnPointerDown()
        {
            if (state != State.Run) return;
            
            if (runMode == RunMode.Left) return;
            
            runMode = RunMode.Left;
            playerTurnLeft.RaiseEvent();
        }

        public void OnPointerUp()
        {
            if (state != State.Run) return;
            
            if (runMode == RunMode.Right) return;
            
            runMode = RunMode.Right;
            playerTurnRight.RaiseEvent();
        }

        public void OnLevelEnd()
        {
            StopRunning();
        }
        
        private void StartRunning()
        {
            state = State.Run;
        }
        
        private void StopRunning()
        {
            state = State.Idle;
        }

        private void UpdateRunSpeedMode()
        {
            var positionX = body.position.x;
            var newRunSpeedMode = positionX < 0f ? RunSpeedMode.Fast : RunSpeedMode.Normal;
            
            if (newRunSpeedMode == runSpeedMode) return;

            runSpeedMode = newRunSpeedMode;

            if (newRunSpeedMode == RunSpeedMode.Normal)
            {
                playerNormalRun.RaiseEvent();
                return;
            }
            
            playerFastRun.RaiseEvent();
        }

        private void CheckBorder()
        {
            if (state != State.Run) return;
            
            if (runMode == RunMode.Straight) return;
            
            var positionX = body.position.x;
            
            if (runMode == RunMode.Right)
            {
                if (positionX < levelData.BorderX) return;

                runMode = RunMode.Straight;
                playerTurnStraight.RaiseEvent();
            }
            
            else if (runMode == RunMode.Left)
            {
                if (positionX > -levelData.BorderX) return;

                runMode = RunMode.Straight;
                playerTurnStraight.RaiseEvent();
            }
        }

        private void MoveVertical()
        {
            var speedX = verticalSpeed * (float) runMode;

            if (state != State.Run)
            {
                speedX = 0f;
            }

            var oldVelocity = body.velocity;
            oldVelocity.x = speedX;
            body.velocity = oldVelocity;
        }

        private void SetForwardSpeed()
        {
            var speed = state == State.Run ? runSpeed : 0f;
            speed *= runSpeedMode == RunSpeedMode.Fast ? levelData.FastRunMultiplier : 1f;

            if (playerCollision.IsBlockedByFellow)
            {
                speed = Mathf.Clamp(speed, 0f, levelData.DummySpeed);
            }
            
            var oldVelocity = body.velocity;
            oldVelocity.z = speed;
            body.velocity = oldVelocity;
        }
        
        
        private enum RunMode
        {
            Right = 1,
            Left = -1,
            Straight = 0
        }
        
        private enum RunSpeedMode
        {
            Normal,
            Fast
        }
        
        private enum State
        {
            Idle,
            Run
        }
    }
}
