using UnityEngine;

public class ScreenOrientation
{
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
            Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
    }
}
