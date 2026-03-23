using UnityEngine;
using System.IO; // BẮT BUỘC: Thư viện để đọc/ghi file

public class Lab6Manager : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        // Tạo đường dẫn: .../AppData/LocalLow/DefaultCompany/ProjectName/player_save.json
        filePath = Application.persistentDataPath + "/player_save.json";
    }

    void Start()
    {
        // 1. TẠO DỮ LIỆU GIẢ
        PlayerData dataToSave = new PlayerData { playerName = "dung", level = 5, coin = 999, health = 100 };

        // 2. LƯU FILE (SAVE)
        SaveGame(dataToSave);

        // 3. ĐỌC FILE (LOAD)
        LoadGame();
    }

    public void SaveGame(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true); // Chuyển sang JSON
        File.WriteAllText(filePath, json);           // Ghi xuống ổ cứng
        Debug.Log("<color=green>Đã lưu file tại: </color>" + filePath);
    }

    public void LoadGame()
    {
        // Kiểm tra xem file có tồn tại không trước khi đọc
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);      // Đọc nội dung file
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            Debug.Log($"<color=yellow>Đã Load:</color> Name {loadedData.playerName},Level {loadedData.level}, Vàng {loadedData.coin}, HP: {loadedData.health}");
        }
        else
        {
            Debug.LogWarning("Không tìm thấy file save!");
        }
    }
}