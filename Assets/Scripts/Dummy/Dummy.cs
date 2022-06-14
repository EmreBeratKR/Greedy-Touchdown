using UnityEngine;

namespace Dummy
{
    [RequireComponent(typeof(ModelRandomizer))]
    [RequireComponent(typeof(Rigidbody))]
    public class Dummy : MonoBehaviour
    {
        [SerializeField] private ModelRandomizer modelRandomizer;
        [SerializeField] private LevelData levelData;
        
        private Rigidbody body;


        public Vector3 LocalPosition
        {
            get => transform.localPosition;
            set => transform.localPosition = value;
        }

    
        private void Start()
        {
            body = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            SetSpeed();
        }

        public void RandomizeModel()
        {
            modelRandomizer.Randomize();
        }

        private void SetSpeed()
        {
            body.velocity = transform.forward * levelData.DummySpeed;
        }
    }
}
