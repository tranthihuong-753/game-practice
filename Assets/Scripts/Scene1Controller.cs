using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Sử dụng TextMeshPro

public class Scene1Controller : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplayText; // Kéo Text hiển thị điểm ở Scene 1 vào đây

    void Update()
    {
        // Liên tục cập nhật điểm lên màn hình Scene 1
        if (scoreDisplayText != null && DataManager.instance != null)
        {
            scoreDisplayText.text = "Current Score: " + DataManager.instance.score;
        }
    }

    // Hàm cho nút Add Score
    public void AddTenScore()
    {
        if (DataManager.instance != null)
        {
            DataManager.instance.score += 10;
            Debug.Log("Added 10 score. Total: " + DataManager.instance.score);
        }
    }

    // Hàm cho nút Next Scene
    public void GoToNextScene()
    {
        SceneManager.LoadScene("Lab3_scene2"); // Đảm bảo Scene2 đã add vào Build Settings
    }
}