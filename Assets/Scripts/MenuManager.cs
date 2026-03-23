using UnityEngine;
using UnityEngine.SceneManagement; // Bắt buộc để chuyển Scene

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Gán dữ liệu vào biến static trước khi chuyển scene
        DataBridge.playerName = "Vudun_Developer";
        DataBridge.selectedLevel = 5;

        Debug.Log("Đã lưu dữ liệu vào DataBridge. Đang chuyển Scene...");

        // Chuyển sang Scene tiếp theo (nhớ add Scene vào Build Settings)
        SceneManager.LoadScene("Lab 1_game");
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 50), "START GAME"))
        {
            StartGame();
        }
    }
}