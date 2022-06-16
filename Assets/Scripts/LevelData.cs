using UnityEngine;

[CreateAssetMenu(menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    [SerializeField, Min(0)] private int levelChunkCount;
    public int LevelChunkCount => levelChunkCount;
    
    [SerializeField, Min(0)] private float chunkLength;
    public float ChunkLength => chunkLength;
    
    [SerializeField, Min(1f)] private float fastRunMultiplier;
    public float FastRunMultiplier => fastRunMultiplier;
    
    [SerializeField, Min(1f)] private float fastRunAnimatorMultiplier;
    public float FastRunAnimatorMultiplier => fastRunAnimatorMultiplier;
    
    [SerializeField, Min(0f)] private float borderX;
    public float BorderX => borderX;
    
    [SerializeField, Min(0f)] private float dummySpeed;
    public float DummySpeed => dummySpeed;
}
