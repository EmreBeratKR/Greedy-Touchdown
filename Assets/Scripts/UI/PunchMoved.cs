using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class PunchMoved : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private AnimationCurve easing;
        [SerializeField] private float duration;


        public void Animate()
        {
            var targetPosition = rectTransform.localPosition;
            rectTransform.localPosition = startPosition;

            rectTransform.DOLocalMove(targetPosition, duration)
                .SetEase(easing);
        }
    }
}
