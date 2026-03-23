using UnityEngine;

public class Lab5Manager : MonoBehaviour
{
    // Kéo file GlobalConfig bạn vừa tạo vào ô này trong Inspector
    public GameConfig config;

    void Start()
    {
        if (config != null)
        {
            Debug.Log("Game Version: " + config.gameVersion);
            Debug.Log("Base Speed: " + config.playerBaseSpeed);
        }
    }
}