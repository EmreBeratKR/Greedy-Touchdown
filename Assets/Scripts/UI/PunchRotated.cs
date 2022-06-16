using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class PunchRotated : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private AnimationCurve easing;
        [SerializeField] private float duration;
        [SerializeField] private float startAngle;


        public void Animate()
        {
            rectTransform.localEulerAngles = Vector3.forward * startAngle;
            rectTransform.DOLocalRotate(Vector3.zero, duration)
                .SetEase(easing);
        }
    }
}
