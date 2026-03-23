using UnityEngine;
using TMPro;

public class InGameDisplay : MonoBehaviour
{
    public TextMeshProUGUI welcomeText;

    void Start()
    {
        // Lấy dữ liệu từ biến static ra để dùng
        if (welcomeText != null)
        {
            welcomeText.text = $"Welcome, {DataBridge.playerName}!\nLevel: {DataBridge.selectedLevel}";
        }

        Debug.Log("Dữ liệu nhận được từ Menu: " + DataBridge.playerName);
    }
}