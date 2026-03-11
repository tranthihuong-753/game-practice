using UnityEngine;
using UnityEngine.SceneManagement; 

public class UIManager : MonoBehaviour
{
    [Header("Settings Panel")]
    public GameObject optionsPanel;

    public void StartGame()
    {
        Debug.Log("Đang tải màn chơi chính...");
    }

    public void OpenOptions()
    {
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(true);
            Debug.Log("Đã mở bảng Options");
        }
    }

    public void CloseOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Đang thoát Game...");
        Application.Quit();
    }
}