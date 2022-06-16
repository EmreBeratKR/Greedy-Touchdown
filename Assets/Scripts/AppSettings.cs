using UnityEngine;

public class AppSettings : MonoBehaviour
{
    private void Start()
    {
        SetFPS();
    }

    private static void SetFPS()
    {
        if (!Application.isMobilePlatform) return;
        
        Application.targetFrameRate = 60;
    }
}
