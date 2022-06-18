using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelInfo : MonoBehaviour
    {
        private const string LevelNumberKey = "Level_Number";
        private const string LevelPrefix = "LEVEL";

        [Header("References")]
        [SerializeField] private SlicedFilledImage progressBar;
        [SerializeField] private Transform indicator;
        [SerializeField] private Transform startAnchor;
        [SerializeField] private Transform endAnchor;
        [SerializeField] private TMP_Text levelNumberField;
        [SerializeField] private PlayerMovement player;
        [SerializeField] private LevelData levelData;
        
        [Header("Values")]
        [SerializeField, Range(0f, 0.1f)] private float smoothness;

        private State state;
        private float progress;
        
        
        private int LevelNumber
        {
            get => PlayerPrefs.GetInt(LevelNumberKey, 0);
            set => PlayerPrefs.SetInt(LevelNumberKey, value);
        }
        
        
        private void Start()
        {
            LoadLevelNumber();
        }

        private void FixedUpdate()
        {
            UpdateProgress();
            UpdateProgressBarSmooth();
        }

        public void OnGameStarted()
        {
            state = State.Active;
        }
        
        public void OnLevelCompleted()
        {
            LevelNumber++;
        }
        
        private void LoadLevelNumber()
        {
            levelNumberField.text = $"{LevelPrefix} {LevelNumber}";
        }

        private void UpdateProgress()
        {
            if (state != State.Active) return;

            var start = player.StartPosition.z;
            var current = player.Position.z;
            var delta = current - start;
            var total = levelData.LevelChunkCount * levelData.ChunkLength;
            progress = Mathf.Clamp01(delta / total);
        }

        private void UpdateProgressBarSmooth()
        {
            var oldProgress = progressBar.fillAmount;
            var smoothProgress = Mathf.Lerp(oldProgress, progress, smoothness);
            progressBar.fillAmount = smoothProgress;
            indicator.localPosition = Vector3.Lerp(startAnchor.localPosition, endAnchor.localPosition, smoothProgress);
        }
        
        private enum State
        {
            Deactive,
            Active
        }
    }
}
