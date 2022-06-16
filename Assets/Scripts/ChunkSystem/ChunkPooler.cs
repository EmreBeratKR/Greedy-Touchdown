using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChunkSystem
{
    public class ChunkPooler : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private ChunkSystem.Chunk groundChunkPrefab;
        [SerializeField] private ChunkSystem.Chunk endChunkPrefab;

        [Header("References")]
        [SerializeField] private Transform chunkParent;
        [SerializeField] private LevelData levelData;
    
        [Header("Values")]
        [SerializeField, Min(0)] private int poolSize;
        [SerializeField, Min(0)] private int behindChunkCount;


        private readonly Queue<ChunkSystem.Chunk> chunks = new Queue<ChunkSystem.Chunk>();
        private float poolLenght;
        private int pooledChunkCount;
        private State state;

        
        private void Start()
        {
            GenerateChunks();
        }

        public void OnGameStarted()
        {
            state = State.Active;
        }

        public void OnPlayerEnteredNextChunk()
        {
            if (state == State.Deactive) return;
        
            if (pooledChunkCount < levelData.LevelChunkCount)
            {
                var firstChunk = chunks.Dequeue();
                var oldPosition = firstChunk.Position;
                oldPosition.z += poolLenght;
                firstChunk.Position = oldPosition;
                chunks.Enqueue(firstChunk);

                if (state != State.Infinite)
                {
                    pooledChunkCount++;
                }
                return;
            }
        
            GenerateEndChunk();
        }

        private void GenerateChunks()
        {
            poolLenght = levelData.ChunkLength * poolSize;
        
            for (int i = 0; i < poolSize; i++)
            {
                var newChunk = Instantiate(groundChunkPrefab, chunkParent);
                var position = Vector3.forward * ((i - behindChunkCount) * levelData.ChunkLength);
                newChunk.Position = position;
                chunks.Enqueue(newChunk);
            }

            pooledChunkCount += poolSize - behindChunkCount;
        }

        private void GenerateEndChunk()
        {
            var endChunk = Instantiate(endChunkPrefab, chunkParent);
            var lastChunk = chunks.Last();
            var endPosition = lastChunk.Position + Vector3.forward * levelData.ChunkLength;
            endChunk.Position = endPosition;

            state = State.Deactive;
        }
    
    
        private enum State
        {
            Infinite,
            Active,
            Deactive
        }
    }
}
