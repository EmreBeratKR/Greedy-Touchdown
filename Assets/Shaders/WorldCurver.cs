using UnityEngine;

namespace Shaders
{
    [CreateAssetMenu(menuName = "World Curver")]
    public class WorldCurver : ScriptableObject
    {
        [SerializeField] private Material[] materialsToCurve;
        [SerializeField, Range(-0.01f, 0.01f)] private float magnitude;
        [SerializeField] private float peekDistance;
        
        
        private static readonly int MagnitudeID = Shader.PropertyToID("_Magnitude");
        private static readonly int PeekDistanceID = Shader.PropertyToID("_Peek_Distance");


        private void OnValidate()
        {
            foreach (var material in materialsToCurve)
            {
                material.SetFloat(MagnitudeID, magnitude);
                material.SetFloat(PeekDistanceID, peekDistance);
            }
        }
    }
}
