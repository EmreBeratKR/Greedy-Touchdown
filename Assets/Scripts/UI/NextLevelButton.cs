using ScriptableEvents.Core.Channels;
using UnityEngine;

namespace UI
{
    public class NextLevelButton : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel nextLevel;
        
        
        public void OnClicked()
        {
            nextLevel.RaiseEvent();
        }
    }
}
