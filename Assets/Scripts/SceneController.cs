using System.Collections;
using Helpers;
using NaughtyAttributes;
using ScriptableEvents.Core.Channels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    [Header("Event Channels")]
    [SerializeField] private VoidEventChannel loadingStarted;
    [SerializeField] private VoidEventChannel loadingEnded;
    
    [SerializeField, Scene] private int 
        fittingRoom,
        game;


    public void LoadGame()
    {
        LoadSceneAsync(game);
    }
    
    public void RestartLevel()
    {
        LoadGame();
    }

    public void NextLevel()
    {
        RestartLevel();
    }

    private Coroutine LoadSceneAsync(int sceneIndex)
    {
        return StartCoroutine(AsyncLoad());

        IEnumerator AsyncLoad()
        {
            var operation = SceneManager.LoadSceneAsync(sceneIndex);
            loadingStarted.RaiseEvent();

            while (!operation.isDone) yield return null;

            yield return new WaitForSeconds(0.5f);
            
            loadingEnded.RaiseEvent();
        }
    }
}
