using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class BubblePanel : MonoBehaviour
{
    [SerializeField] private Vector3 hideMovement;
    [SerializeField] private Ease easing;
    [SerializeField] private float duration;
    [SerializeField] private bool showOnStart;
    
    private Vector3 HiddenPosition => showedPosition + hideMovement;
    
    private Vector3 showedPosition;
    private State state;


    private void Start()
    {
        showedPosition = transform.localPosition;
        transform.localPosition = HiddenPosition;
        
        if (showOnStart) Show();
    }

    [Button(enabledMode: EButtonEnableMode.Playmode)]
    public void Show()
    {
        if (state == State.Showed) return;
        
        state = State.Showed;

        transform.DOKill();
        
        transform.DOLocalMove(showedPosition, duration)
            .SetEase(easing);
    }

    [Button(enabledMode: EButtonEnableMode.Playmode)]
    public void Hide()
    {
        if (state == State.Hidden) return;
        
        state = State.Hidden;

        transform.DOKill();
        
        transform.DOLocalMove(HiddenPosition, duration)
            .SetEase(easing);
    }
    
    
    
    private enum State
    {
        Hidden,
        Showed
    } 
}
