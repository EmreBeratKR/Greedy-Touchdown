using UnityEngine;

namespace Shaders
{
    [CreateAssetMenu(menuName = "World Curver")]
    public class WorldCurver : ScriptableObject
    {
        [SerializeField] private Material[] materialsToCurve;
        [SerializeField, Range(-0.01f, 0.01f)] private float magnitude;
        [SerializeField] private float peekDistance;
        [SerializeField] private bool active;
        
        
        private static readonly int MagnitudeID = Shader.PropertyToID("_Magnitude");
        private static readonly int PeekDistanceID = Shader.PropertyToID("_Peek_Distance");


        private void OnValidate()
        {
            var magnitudeValue = active ? magnitude : 0f;
            var peekDistanceValue = active ? peekDistance : 0f;
            
            foreach (var material in materialsToCurve)
            {
                material.SetFloat(MagnitudeID, magnitudeValue);
                material.SetFloat(PeekDistanceID, peekDistanceValue);
            }
        }
    }
}
