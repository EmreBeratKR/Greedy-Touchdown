using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Chunk
{
    public class ChunkPooler : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Chunk groundChunkPrefab;
        [SerializeField] private Chunk endChunkPrefab;

        [Header("References")]
        [SerializeField] private Transform chunkParent;
    
        [Header("Values")]
        [SerializeField, Min(0)] private int poolSize;
        [SerializeField, Min(0f)] private float chunkSize;
        [SerializeField, Min(0)] private int behindChunkCount;
        [SerializeField, Min(0)] private int chunkCycleCount;


        private static readonly Queue<Chunk> Chunks = new Queue<Chunk>();
        private float poolLenght;
        private int pooledChunkCount;
        private State state;

        private void Start()
        {
            GenerateChunks();
        }

        public void OnPlayerEnteredNextChunk()
        {
            if (state == State.Deactive) return;
        
            if (pooledChunkCount < chunkCycleCount)
            {
                var firstChunk = Chunks.Dequeue();
                var oldPosition = firstChunk.Position;
                oldPosition.z += poolLenght;
                firstChunk.Position = oldPosition;
                Chunks.Enqueue(firstChunk);

                pooledChunkCount++;
                return;
            }
        
            GenerateEndChunk();
        }

        private void GenerateChunks()
        {
            poolLenght = chunkSize * poolSize;
        
            for (int i = 0; i < poolSize; i++)
            {
                var newChunk = Instantiate(groundChunkPrefab, chunkParent);
                var position = Vector3.forward * ((i - behindChunkCount) * chunkSize);
                newChunk.Position = position;
                Chunks.Enqueue(newChunk);
            }

            pooledChunkCount += poolSize - behindChunkCount;
        }

        private void GenerateEndChunk()
        {
            var endChunk = Instantiate(endChunkPrefab, chunkParent);
            var lastChunk = Chunks.Last();
            var endPosition = lastChunk.Position + Vector3.forward * chunkSize;
            endChunk.Position = endPosition;

            state = State.Deactive;
        }
    
    
        private enum State
        {
            Active,
            Deactive
        }
    }
}
