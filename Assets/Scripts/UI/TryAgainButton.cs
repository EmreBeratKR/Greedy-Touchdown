using ScriptableEvents.Core.Channels;
using UnityEngine;

namespace UI
{
    public class TryAgainButton : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel levelRestarted;
        
        
        public void OnClicked()
        {
            levelRestarted.RaiseEvent();
        }
    }
}
