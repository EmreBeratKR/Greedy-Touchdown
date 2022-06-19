using System.Collections;
using DG.Tweening;
using Helpers;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LoadingCanvas : Singleton<LoadingCanvas>
    {
        private const string LoadingPrefix = "Loading";
        private const string DotCharacter = ".";
        private const int MaxDotCount = 3;
        
        [Header("References")]
        [SerializeField] private GameObject main;
        [SerializeField] private TMP_Text loadingField;
        [SerializeField] private Transform leftAnchor;
        [SerializeField] private Transform rightAnchor;
        [SerializeField] private Transform heightAnchor;
        [SerializeField] private Transform ball;

        [Header("Animation Setting")]
        [SerializeField] private AnimationCurve heightCurve;
        [SerializeField, Min(0f)] private float duration;
        [SerializeField, Min(0f)] private float interval;
        [SerializeField, Range(0f, 90f)] private float leftTilt;
        [SerializeField, Range(0f, 90f)] private float rightTilt;


        private Sequence sequence;
        private bool isPlaying;


        private IEnumerator Start()
        {
            OnLoadingStarted();

            yield return new WaitForSeconds(2f);
            
            OnLoadingEnded();
        }

        public void OnLoadingStarted()
        {
            main.SetActive(true);
            PlayAnimation();
        }

        public void OnLoadingEnded()
        {
            main.SetActive(false);
            StopAnimation();
        }

        
        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void PlayAnimation()
        {
            if (isPlaying) return;

            isPlaying = true;
            
            var leftAnchorPosition = leftAnchor.position;
            var rightAnchorPosition = rightAnchor.position;
            var heightAnchorPosition = heightAnchor.position;

            var leftRotation = Vector3.forward * leftTilt;
            var rightRotation = Vector3.forward * -rightTilt;

            sequence = DOTween.Sequence();

            ball.transform.position = leftAnchorPosition;
            ball.eulerAngles = leftRotation;

            sequence.Insert(0f,
                ball.DOMoveX(rightAnchorPosition.x, duration));

            sequence.Insert(0f,
                ball.DOMoveY(heightAnchorPosition.y, duration)
                    .SetEase(heightCurve));

            sequence.Insert(0f,
                ball.DORotate(rightRotation, duration));

            sequence.AppendInterval(interval);
            
            sequence.SetLoops(-1);

            StartCoroutine(LoadingFieldAnimation());
        }

        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void StopAnimation()
        {
            StopAllCoroutines();
            sequence.Kill();
            isPlaying = false;
        }

        private IEnumerator LoadingFieldAnimation()
        {
            while (true)
            {
                var elapsed = sequence.Elapsed(false);
                elapsed = Mathf.Clamp(elapsed, 0f, duration);
                var dotInterval = duration / MaxDotCount;
                var dotCount = Mathf.FloorToInt(elapsed / dotInterval);
                
                var newLoadingText = LoadingPrefix;
                for (int i = 0; i < dotCount; i++)
                {
                    newLoadingText += DotCharacter;
                }

                loadingField.text = newLoadingText;

                yield return null;
            }
        }
    }
}
