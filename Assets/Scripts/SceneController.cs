using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static int ActiveSceneIndex => SceneManager.GetActiveScene().buildIndex;
    
    
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(ActiveSceneIndex);
    }

    public void NextLevel()
    {
        RestartLevel();
    }
}
