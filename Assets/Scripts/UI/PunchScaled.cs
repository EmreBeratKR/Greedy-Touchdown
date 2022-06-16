using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class PunchScaled : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private AnimationCurve easing;
        [SerializeField] private float duration;
        

        public void Animate()
        {
            rectTransform.localScale = Vector3.zero;
            rectTransform.DOScale(Vector3.one, duration)
                .SetEase(easing);
        }
    }
}
