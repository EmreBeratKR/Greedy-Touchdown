using DG.Tweening;
using ScriptableEvents.Core.Channels;
using UnityEngine;

namespace UI
{
    public class TouchToPlay : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private VoidEventChannel gameStarted;

        [Header("References")]
        [SerializeField] private RectTransform hand;
        [SerializeField] private RectTransform text;
        
        [Header("Values")]
        [SerializeField, Min(0f)] private float duration;
        [SerializeField, Range(0f, 1f)] private float shrinkness;
        
        private Sequence handSequence;
        private Sequence textSequence;

        
        private void Start()
        {
            Animate();
        }

        private void Animate()
        {
            handSequence = DOTween.Sequence();

            handSequence.Append(hand.DOScale(Vector3.one * shrinkness, duration * 0.5f)
                .SetEase(Ease.InSine));
            
            handSequence.Append(hand.DOScale(Vector3.one, duration * 0.5f)
                .SetEase(Ease.OutSine));

            handSequence.SetLoops(-1);

            textSequence = DOTween.Sequence();
            
            textSequence.Append(text.DOScale(Vector3.one * shrinkness, duration * 0.5f)
                .SetEase(Ease.InSine));
            
            textSequence.Append(text.DOScale(Vector3.one, duration * 0.5f)
                .SetEase(Ease.OutSine));

            textSequence.SetLoops(-1);
        }

        public void OnPointerDown()
        {
            gameStarted.RaiseEvent();
            handSequence.Kill();
            gameObject.SetActive(false);
        }
    }
}
