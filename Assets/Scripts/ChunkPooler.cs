using System.Collections.Generic;
using UnityEngine;

public class ChunkPooler : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private Chunk groundChunkPrefab, endChunkPrefab;

    [Header("Values")]
    [SerializeField] private int poolSize;
    [SerializeField] private float chunkSize;
    [SerializeField] private int chunkCycleCount;

    private Queue<Chunk> chunks;

    private void Start()
    {
        GenerateChunks();
    }

    private void GenerateChunks()
    {
        chunks = new Queue<Chunk>();

        for (int i = 0; i < poolSize; i++)
        {
            var newChunk = Instantiate(groundChunkPrefab, transform);
            var position = Vector3.forward * (i * chunkSize);
            newChunk.SetPosition(position);
            chunks.Enqueue(newChunk);
        }
    }
}
