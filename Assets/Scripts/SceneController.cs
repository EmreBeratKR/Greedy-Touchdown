using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField, Scene] private int 
        fittingRoom,
        game;


    public void LoadGame()
    {
        SceneManager.LoadScene(game);
    }
    
    public void RestartLevel()
    {
        LoadGame();
    }

    public void NextLevel()
    {
        RestartLevel();
    }
}
