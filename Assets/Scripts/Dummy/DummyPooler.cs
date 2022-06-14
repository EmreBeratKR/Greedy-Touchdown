using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dummy
{
    public class DummyPooler : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Dummy[] dummyPrefabs;

        [Header("References")] 
        [SerializeField] private LevelData levelData;
        [SerializeField] private Transform dummyParent;
        
        [Header("Values")]
        [SerializeField] private int poolSize;
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;
        [SerializeField] private bool isOppositeDirection;


        private readonly Queue<Dummy> dummies = new Queue<Dummy>();


        private Dummy RandomDummyPrefab => dummyPrefabs[Random.Range(0, dummyPrefabs.Length)];
        private float RandomDistance => Random.Range(minDistance, maxDistance);

            
        private void Start()
        {
            transform.position = Vector3.right * (levelData.BorderX * (isOppositeDirection ? -1f : 1f));
            SpawnDummies();
        }

        public void OnDummyCollected()
        {
            var firstDummy = dummies.Dequeue();
            var lastDummy = dummies.Last();
            var oldLocalPosition = firstDummy.LocalPosition;
            oldLocalPosition.z = lastDummy.LocalPosition.z + RandomDistance;
            firstDummy.LocalPosition = oldLocalPosition;
            dummies.Enqueue(firstDummy);
        }

        private void SpawnDummies()
        {
            var lastDummyLocalPosition = Vector3.zero;
            
            for (int i = 0; i < poolSize; i++)
            {
                var newDummy = Instantiate(RandomDummyPrefab, dummyParent);
                var currentDummyLocalPosition = lastDummyLocalPosition + Vector3.forward * RandomDistance;
                
                newDummy.LocalPosition = currentDummyLocalPosition;
                newDummy.RandomizeModel();
                dummies.Enqueue(newDummy);
                
                lastDummyLocalPosition = currentDummyLocalPosition;
            }
        }
    }
}