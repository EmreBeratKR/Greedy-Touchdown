using ScriptableEvents.Core.Channels;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler
{
    [SerializeField] private VoidEventChannel pointerDownChannel;
    [SerializeField] private VoidEventChannel pointerUpChannel;



    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDownChannel.RaiseEvent();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerUpChannel.RaiseEvent();
    }
}
