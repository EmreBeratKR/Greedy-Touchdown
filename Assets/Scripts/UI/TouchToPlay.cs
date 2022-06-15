using DG.Tweening;
using ScriptableEvents.Core.Channels;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class TouchToPlay : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private VoidEventChannel gameStarted;
        
        [Header("Values")]
        [SerializeField, Min(0f)] private float duration;
        [SerializeField, Range(0f, 1f)] private float shrinkness;
        
        private RectTransform rectTransform;
        private Sequence sequence;

        
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            Animate();
        }

        private void Animate()
        {
            sequence = DOTween.Sequence();

            sequence.Append(rectTransform.DOScale(Vector3.one * shrinkness, duration * 0.5f)
                .SetEase(Ease.InSine));
            
            sequence.Append(rectTransform.DOScale(Vector3.one, duration * 0.5f)
                .SetEase(Ease.OutSine));

            sequence.SetLoops(-1);
        }

        public void OnPointerDown()
        {
            gameStarted.RaiseEvent();
            sequence.Kill();
            gameObject.SetActive(false);
        }
    }
}
