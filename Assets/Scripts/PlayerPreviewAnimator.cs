using NaughtyAttributes;
using UnityEngine;

public class PlayerPreviewAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField ,AnimatorParam(nameof(animator))] 
    private int anger;
    

    public void OnCharacterTypeChanged()
    {
        PlayAnger();
    }

    private void PlayAnger()
    {
        animator.SetTrigger(anger);
    }
}
