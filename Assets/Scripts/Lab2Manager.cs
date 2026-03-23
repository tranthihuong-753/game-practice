using UnityEngine;
using TMPro;

public class Lab2Manager : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    private int highscore = 0;

    void Start()
    {
        // 1. LẤY DỮ LIỆU (LOAD)
        // Nếu chưa có key "Highscore", nó sẽ trả về giá trị mặc định là 0
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (infoText != null)
            infoText.text = $"Highscore: {highscore}";
    }

    // 2. LƯU DỮ LIỆU (SAVE)
    public void SaveNewHighscore(int newScore)
    {
        if (newScore > highscore)
        {
            highscore = newScore;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save(); // Lệnh này để đảm bảo dữ liệu được ghi xuống ổ cứng ngay lập tức
            Debug.Log("Đã lưu kỷ lục mới: " + highscore);
            UpdateUI();
        }
    }

    // 3. XÓA DỮ LIỆU (DELETE)
    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore"); // Xóa riêng key này
        // PlayerPrefs.DeleteAll(); // Hoặc xóa sạch sành sanh mọi thứ
        highscore = 0;
        UpdateUI();
        Debug.Log("Đã xóa kỷ lục!");
    }

    // Dùng OnGUI để test phím bấm vì máy bạn đang gặp vấn đề với Update
    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            if (e.keyCode == KeyCode.Space) SaveNewHighscore(highscore + 10);
            if (e.keyCode == KeyCode.R) ResetHighscore();
        }
    }
}