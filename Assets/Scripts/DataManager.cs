using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string playerName = "Vudun";
    public int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại object này khi sang Scene mới
        }
        else
        {
            Destroy(gameObject); // Xóa bản sao nếu lỡ quay lại Scene 1
        }
    }
}